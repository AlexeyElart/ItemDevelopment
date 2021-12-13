using Dapper;
using ItemDevelopment.Logging;
using ItemDevelopment.Repositories;
using ItemDevelopment.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItemDevelopment
{
    public partial class FormDevelopmentIten : Form
    {
        string tecDocName;
        string tecDocNameCross;

        string connectionString = "SERVER=172.16.10.48;DATABASE=Elart;UID=ImageCombinator;PASSWORD=?user4Image;SslMode=none;Charset=utf8;Default Command Timeout = 3000;Connect Timeout=600;Pooling=false;";
        List<string> brands;
        Dictionary<string, string> renamedBrands;
        List<PictureFileInfo> picureFileInfos;
        private readonly LastOperationsLogger _lastOperationsLogger;

        public FormDevelopmentIten()
        {
            InitializeComponent();
            picureFileInfos = new List<PictureFileInfo>();
            _lastOperationsLogger = new LastOperationsLogger(this, richTextBoxLogger);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Picture's paths";
            column1.Width = 420;
            column1.ReadOnly = true;
            column1.Name = "paths";
            column1.Frozen = true;
            column1.CellTemplate = new DataGridViewLinkCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Action";
            column2.Width = 90;
            column2.ReadOnly = true;
            column2.Name = "action";
            column2.Frozen = true;
            column2.CellTemplate = new DataGridViewButtonCell();

            dataGridViewPictures.Columns.Add(column1);
            dataGridViewPictures.Columns.Add(column2);
        }

        private void comboBoxSourceDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                AsvelaRepository asvelaRepository = new AsvelaRepository(connection);
                TecDocRepository tecDocRepository = new TecDocRepository(connection, "Temp");
                string[] suppliers = asvelaRepository.GetSuppliers().ToArray();
                comboBoxSupplier.Items.AddRange(suppliers);

                brands = connection.Query<string>("Select distinct brand from Temp.Header").ToList();
                tecDocName = "Temp";
                tecDocNameCross = "Temp";
                comboBoxManufacturer.Items.AddRange(brands.ToArray());

                comboBoxBrands.Items.Clear();
                if (comboBoxSourceDB.SelectedItem.ToString() == "Elart TecDoc")
                {
                    brands = connection.Query<string>("Select distinct brand from ElartTecDoc.Header").ToList();
                    tecDocName = "ElartTecDoc";
                }

                renamedBrands = connection.Query<(string, string)>("SELECT OriginalBrandName, NewBrandName FROM Elart.BrandsRename;")
                    .ToDictionary(x => x.Item1, x => x.Item2);

                comboBoxBrands.Items.AddRange(brands.ToArray());

            }
        }

        private void textBoxNumber_TextChanged(object sender, EventArgs e)
        {
            string brandName = comboBoxBrands.SelectedItem.ToString();
            string brandNameForSKU = renamedBrands.ContainsKey(brandName) ? renamedBrands[brandName] : brandName; 
            if (brandNameForSKU.Contains("CALORSTAT"))
            {
                brandNameForSKU = "CBV";
            }
            string result = brandNameForSKU + textBoxNumber.Text;
            textBoxSKU.Text = result.Replace(" ", "").Replace(".", "").Replace("-", "").Replace("/", "").Replace("\\", "")
                                    .Replace("+", "").Replace("(", "").Replace(")", "").Replace("&", "").ToUpper();
            comboBoxSupplier.SelectedItem = null;

            pictureBox1.Image = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                (string, string, int) fromDb = connection.Query<(string, string, int)>($"select sku, supplier, supplier_id from asvela.supplier_data where asvela_sku = \"{textBoxSKU.Text}\"").FirstOrDefault();

                if (!string.IsNullOrEmpty(fromDb.Item1))
                {
                    textBoxSupplierSKU.Text = fromDb.Item1;
                }
                else
                {
                    textBoxSupplierSKU.Clear();
                }
                if (!string.IsNullOrEmpty(fromDb.Item2))
                {                    
                    comboBoxSupplier.SelectedItem = fromDb.Item2;
                }
                else
                {
                    textBoxSupplierSKU.Clear();
                }

                string weight = connection.Query<string>($"select weight from asvela.All_weights where sku = \"{textBoxSKU.Text}\"").FirstOrDefault();
                if (!string.IsNullOrEmpty(weight))
                {
                    textBoxWeight.Text = weight;
                }
                else
                {
                    textBoxWeight.Clear();
                }

                string queTecDoc = "select distinct GD.graphic_file_number, GD.doc_key, SD.supplier_id from asvela.supplier_data SD " +
                    "join `Temp`.`Allocation_of_Graphics_to_Article_Numbers` AGAN on AGAN.man_article_number = SD.tecdoc_number " +
                    $"join `Temp`.`Graphics_Documents` GD on GD.graphic_number = AGAN.graphic_number where SD.asvela_sku = \"{textBoxSKU.Text}\" order by AGAN.sort_key";

                List<(string, int, int)> graphics = connection.Query<(string, int, int)>(queTecDoc).ToList();

                if (graphics == null || graphics.Count == 0)
                {
                    queTecDoc = "select distinct GD.graphic_file_number, GD.doc_key, SD.supplier_id from asvela.supplier_data SD " +
                        "join `ElartTecDoc`.`Allocation_of_Graphics_to_Article_Numbers` AGAN on AGAN.man_article_number = SD.tecdoc_number " +
                        $"join `ElartTecDoc`.`Graphics_and_Documents` GD on GD.graphic_number = AGAN.graphic_number where SD.asvela_sku = \"{textBoxSKU.Text}\" order by AGAN.sort_key";
                    graphics = connection.Query<(string, int, int)>(queTecDoc).ToList();
                }



                foreach (var graphic in graphics)
                {
                    if (!string.IsNullOrEmpty(graphic.Item1))
                    {
                        string folder = graphic.Item3.ToString();
                        while (folder.Length < 4)
                        {
                            folder = folder.Insert(0, "0");
                        }
                        string fileExtention = "";
                        string fileName = graphic.Item1;

                        switch (graphic.Item2)
                        {
                            case 1:
                                fileExtention = ".BMP";
                                break;
                            case 3:
                                fileExtention = ".JPG";
                                break;
                            case 5:
                                fileExtention = ".JPG";
                                break;
                            case 6:
                                fileExtention = ".PNG";
                                break;
                            case 7:
                                fileExtention = ".GIF";
                                break;
                            default:
                                fileExtention = ".JPG";
                                break;
                        }
                        string path = "E:\\TecDocs\\2104\\PIC_FILES\\" + folder + "\\PIC.7z.001\\" + fileName + fileExtention;
                        if (File.Exists(path))
                        {
                            pictureBox1.Load(path);
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            //pictureBox1.Show();
                        }

                    }
                    else
                    {
                        //pictureBox1.Image = null;
                    }
                }

            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                FillSupplierDataAndElartItems();
                FillWeightAndPrice();
                FillPartType();
                FillArticleLinkage();
                FillReferenceNumbers();
                FillCriterions();
                SavePictureInDirectoryTree();
                FillGraphicAllocation();
                RemoveFromListedItemsTable();
                _lastOperationsLogger.Add("\n\n");
            }
            catch (Exception exc)
            {
                _lastOperationsLogger.Add(exc.Message);
            }
        }

        private void RemoveFromListedItemsTable()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string asvelaSKU = textBoxSKU.Text;
                int itemID = connection.Query<int>($"select id from Elart.Items where sku = \"{asvelaSKU}\"").FirstOrDefault();
                if(itemID > 0)
                {
                    connection.Execute($"delete from Elart.ListingItemStatus where ItemID = {itemID}");
                }
                
            }
        }

        private void FillWeightAndPrice()
        {
            string asvelaSKU = textBoxSKU.Text;

            string weightStr = textBoxWeight.Text;
            double weight;

            string priceStr = textBoxPrice.Text;
            double price;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                int weightId = connection.Query<int>($"select id from asvela.All_weights where sku = \"{asvelaSKU}\"").FirstOrDefault();

                if (weightId == 0)
                {
                    if (double.TryParse(weightStr, out weight))
                    {
                        connection.Execute($"insert into asvela.All_weights (sku, weight) values (\"{asvelaSKU}\", {weight.ToString().Replace(",", ".")})");
                        _lastOperationsLogger.Add($"Weight {weight}kg added in DB");
                    }
                    else
                    {
                        throw new Exception("Weight needed, but incorrect");
                    }
                }
                else
                {
                    if (double.TryParse(weightStr, out weight))
                    {
                        connection.Execute($"update asvela.All_weights set weight = {weight.ToString().Replace(",", ".")} where id = {weightId}");
                        _lastOperationsLogger.Add("Weight updated in DB");
                    }
                    else
                    {
                        throw new Exception("Weight incorrect");
                    }
                }

                int priceId = connection.Query<int>($"select SI.Id from Elart.SupplierItems SI join Elart.Items I on SI.ItemID=I.ID where I.SKU = \"{asvelaSKU}\"").FirstOrDefault();

                if (priceId == 0)
                {
                    if (double.TryParse(priceStr, out price))
                    {
                        int itemID = connection.Query<int>($"select id from Elart.Items where SKU = \"{asvelaSKU}\"").FirstOrDefault();
                        string queIns = $"insert into Elart.SupplierItems (SupplierID, ItemID, Count, CreateDate, Price, Currency) " +
                            $"values (8, {itemID}, 1, \"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}\", {price.ToString().Replace(",", ".")}, \"GBP\")";
                        connection.Execute(queIns);
                        _lastOperationsLogger.Add($"Price {price} GBP added in DB");
                    }
                    else
                    {
                        _lastOperationsLogger.Add($"Price DON'T added in DB");
                        //throw new Exception("Price needed, but incorrect");
                    }
                }
                else
                {
                    _lastOperationsLogger.Add("Price already exist in DB");
                }
            }
        }

        private void FillGraphicAllocation()
        {
            string crossBrandName = comboBoxManufacturer.SelectedItem.ToString();
            string crossTecDocNumber = textBoxTecDocNumber.Text;
            string brandName = comboBoxBrands.SelectedItem.ToString();
            string asvelaSKU = textBoxSKU.Text;
            string tecDocNumber = textBoxNumber.Text;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                int crossSupplierId = GetSupplierId(connection, crossBrandName, tecDocNameCross);
                int supplierId = GetSupplierId(connection, brandName, tecDocName);

                string alreadyExistTecdocNumber = connection.Query<string>("SELECT man_article_number FROM ElartTecDoc.Allocation_of_Graphics_to_Article_Numbers " +
                   $"WHERE man_article_number = \"{tecDocNumber}\" and supplier_id = {supplierId}").FirstOrDefault();

                if (string.IsNullOrEmpty(alreadyExistTecdocNumber))
                {
                    for (int i = 0; i < picureFileInfos.Count; i++)
                    {
                        int extentionId = connection.Query<int>($"SELECT doc_key FROM Temp.Document_Types where extension = \"{picureFileInfos[i].Extention.Trim('.').ToUpper()}\"").FirstOrDefault();
                        int graphicId = connection
                            .Query<int>($"INSERT INTO ElartTecDoc.Graphics_and_Documents (graphic_file_number, doc_key) values (\"{asvelaSKU + "_" + i.ToString()}\", {extentionId}); " +
                            $"SELECT MAX(graphic_number) FROM ElartTecDoc.Graphics_and_Documents;")
                            .FirstOrDefault();
                        connection.Execute("INSERT INTO ElartTecDoc.Allocation_of_Graphics_to_Article_Numbers (man_article_number, supplier_id, sort_key, graphic_number) " +
                            $"VALUES (\"{tecDocNumber}\", {supplierId}, {i + 1}, {graphicId})");
                    }
                    _lastOperationsLogger.Add($"{picureFileInfos.Count} pictures was added in DB");
                }
            }

        }

        private void SavePictureInDirectoryTree()
        {
            string folder;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string brandName = comboBoxBrands.SelectedItem.ToString();
                int supplierId = GetSupplierId(connection, brandName, tecDocName);
                folder = CreateFolderName(supplierId);
            }

            string asvelaSKU = textBoxSKU.Text;

            FtpLoader ftpLoader = new FtpLoader();
            for (int i = 0; i < picureFileInfos.Count; i++)
            {
                string newShortFileName = $"{asvelaSKU}_{i}{picureFileInfos[i].Extention}";
                string newFileName = $"E:\\TecDocs\\2104\\PIC_FILES\\{folder}\\PIC.7z.001\\{newShortFileName}";

                if (!Directory.Exists("E:\\TecDocs\\2104" + "\\PIC_FILES\\" + folder))
                {
                    Directory.CreateDirectory("E:\\TecDocs\\2104" + "\\PIC_FILES\\" + folder);
                    Directory.CreateDirectory("E:\\TecDocs\\2104" + "\\PIC_FILES\\" + folder + "\\PIC.7z.001");
                }

                string brandName = comboBoxBrands.SelectedItem.ToString();
                if (!File.Exists(newFileName))
                {
                    File.Copy(picureFileInfos[i].FullFileName, newFileName);
                    _lastOperationsLogger.Add($"{newShortFileName} added to {folder} folder");
                }

                ftpLoader.Upload(File.ReadAllBytes(newFileName), newShortFileName, brandName);
                _lastOperationsLogger.Add($"{newShortFileName} uploaded to FTP-server");
            }

        }

        private void FillCriterions()
        {
            string crossBrandName = comboBoxManufacturer.SelectedItem.ToString();
            string crossTecDocNumber = textBoxTecDocNumber.Text;
            string brandName = comboBoxBrands.SelectedItem.ToString();

            string tecDocNumber = textBoxNumber.Text;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                int crossSupplierId = GetSupplierId(connection, crossBrandName, tecDocNameCross);
                int supplierId = GetSupplierId(connection, brandName, tecDocName);

                string alreadyExistTecdocNumber = connection.Query<string>("SELECT man_article_number FROM ElartTecDoc.Article_Criteria " +
                   $"WHERE man_article_number = \"{tecDocNumber}\" and supplier_id = {supplierId}").FirstOrDefault();

                if (string.IsNullOrEmpty(alreadyExistTecdocNumber))
                {
                    IEnumerable<(int, string, string, int, int, string, int, int, int)> strsInAC = connection
                   .Query<(int, string, string, int, int, string, int, int, int)>("select table_id, Reserved, country_code, sort_key, criterion_id, criterion_value, " +
                   "immediate_display, is_exclusion, DeleteFlag " +
                   $"from Temp.Article_Criteria where man_article_number = \"{crossTecDocNumber}\" and supplier_id = {crossSupplierId};");

                    foreach (var str in strsInAC)
                    {
                        connection.Execute("INSERT INTO ElartTecDoc.Article_Criteria (man_article_number, supplier_id, table_id, Reserviert, country_code, sort_key, " +
                            "criterion_id, criterion_value, immediate_display, is_exclusion, Losch_Flag) " +
                        $"VALUES (\"{tecDocNumber}\", {supplierId}, {str.Item1}, \"{str.Item2}\", \"{str.Item3}\", {str.Item4}, {str.Item5}, \"{str.Item6}\", {str.Item7}, " +
                        $"{str.Item8}, {str.Item9})");
                    }
                    _lastOperationsLogger.Add($"Was added {strsInAC.Count()} criterias in Article_Criteria");
                }
            }
        }

        private void FillReferenceNumbers()
        {
            string crossBrandName = comboBoxManufacturer.SelectedItem.ToString();
            string crossTecDocNumber = textBoxTecDocNumber.Text;
            string brandName = comboBoxBrands.SelectedItem.ToString();

            string tecDocNumber = textBoxNumber.Text;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                int crossSupplierId = GetSupplierId(connection, crossBrandName, tecDocNameCross);
                int supplierId = GetSupplierId(connection, brandName, tecDocName);

                string alreadyExistTecdocNumber = connection.Query<string>("SELECT man_article_number FROM ElartTecDoc.Reference_Numbers " +
                   $"WHERE man_article_number = \"{tecDocNumber}\" and supplier_id = {supplierId}").FirstOrDefault();

                if (string.IsNullOrEmpty(alreadyExistTecdocNumber))
                {
                    IEnumerable<(int, int, string, string, int, int, int, string, int, string)> strsInRN = connection
                    .Query<(int, int, string, string, int, int, int, string, int, string)>("select table_id, manufacturer_id, country_code, oe_id, is_exclusion, sort, " +
                    "is_builds_with_parent, reference_type, DeleteFlag, oe_id_search " +
                    $"from Temp.Reference_Numbers where man_article_number = \"{crossTecDocNumber}\" and supplier_id = {crossSupplierId};");

                    if (strsInRN.Count() == 0)
                    {
                        throw new Exception("Reference Numbers not found");
                    }
                    foreach (var str in strsInRN)
                    {
                        connection.Execute("INSERT INTO ElartTecDoc.Reference_Numbers (man_article_number, supplier_id, table_id, manufacturer_id, country_code, oe_id, is_exclusion, sort, " +
                            "is_builds_with_parent, reference_type, Losch_Flag, oe_id_search) " +
                        $"VALUES (\"{tecDocNumber}\", {supplierId}, {str.Item1}, {str.Item2}, \"{str.Item3}\", \"{str.Item4}\", {str.Item5}, {str.Item6}, {str.Item7}, " +
                        $"\"{str.Item8}\", {str.Item9}, \"{str.Item10}\")");
                    }
                    _lastOperationsLogger.Add($"Was added {strsInRN.Count()} references in Refereces_numbers/");
                }
            }
        }

        private void FillArticleLinkage()
        {
            string crossBrandName = comboBoxManufacturer.SelectedItem.ToString();
            string crossTecDocNumber = textBoxTecDocNumber.Text;
            string brandName = comboBoxBrands.SelectedItem.ToString();

            string tecDocNumber = textBoxNumber.Text;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                int crossSupplierId = GetSupplierId(connection, crossBrandName, tecDocNameCross);
                int supplierId = GetSupplierId(connection, brandName, tecDocName);

                string alreadyExistTecdocNumber = connection.Query<string>("SELECT man_article_number FROM ElartTecDoc.Article_Linkage " +
                    $"WHERE man_article_number = \"{tecDocNumber}\" and supplier_id = {supplierId}").FirstOrDefault();

                StringBuilder insertPart = new StringBuilder();
                if (string.IsNullOrEmpty(alreadyExistTecdocNumber))
                {
                    IEnumerable<(int, int, int, int, int, int)> strsInAL = connection
                    .Query<(int, int, int, int, int, int)>("select table_id, gen_article_id, linkagetypeid, VknZielNr, sequential_number, DeleteFlag " +
                    $"from Temp.Article_Linkage where man_article_number = \"{crossTecDocNumber}\" and supplier_id = {crossSupplierId};");
                    if (strsInAL.Count() == 0)
                    {
                        throw new Exception("Article Linkages not found");
                    }
                    foreach (var str in strsInAL)
                    {
                        //connection.Execute("INSERT INTO ElartTecDoc.Article_Linkage (man_article_number, supplier_id, table_id, gen_article_id, " +
                        //    "VknZielArt, VknZielNr, sequential_number, Losch_Flag) " +
                        //$"VALUES (\"{tecDocNumber}\", {supplierId}, {str.Item1}, {str.Item2}, {str.Item3}, {str.Item4}, {str.Item5}, {str.Item6})");
                        insertPart.Append($"(\"{tecDocNumber}\", {supplierId}, {str.Item1}, {str.Item2}, {str.Item3}, {str.Item4}, {str.Item5}, {str.Item6}),");
                    }
                    string values = insertPart.ToString().Trim(',');
                    string que = "INSERT INTO ElartTecDoc.Article_Linkage (man_article_number, supplier_id, table_id, gen_article_id, " +
                            "VknZielArt, VknZielNr, sequential_number, Losch_Flag) VALUES " + values;

                    _lastOperationsLogger.Add($"Was added {strsInAL.Count()} links in ArticleLinkage");

                    connection.Execute(que);

                }
            }
        }

        private void FillPartType()
        {
            string crossBrandName = comboBoxManufacturer.SelectedItem.ToString();
            string crossTecDocNumber = textBoxTecDocNumber.Text;
            string brandName = comboBoxBrands.SelectedItem.ToString();

            string tecDocNumber = textBoxNumber.Text;


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                int crossSupplierId = GetSupplierId(connection, crossBrandName, tecDocNameCross);
                int supplierId = GetSupplierId(connection, brandName, tecDocName);

                string alreadyExistTecdocNumber = connection.Query<string>("SELECT man_article_number FROM ElartTecDoc.Article_to_Generic_Article_Allocation " +
                    $"WHERE man_article_number = \"{tecDocNumber}\" and supplier_id = {supplierId}").FirstOrDefault();

                if (string.IsNullOrEmpty(alreadyExistTecdocNumber))
                {
                    (int, int, int) strInAGAA = connection.Query<(int, int, int)>($"select table_id, gen_article_id, DeleteFlag " +
                                                        $"From Temp.Article_to_Generic_Article_Allocation where man_article_number = \"{crossTecDocNumber}\" and supplier_id = {crossSupplierId};").FirstOrDefault();
                    if (strInAGAA.Item1 == 0 && strInAGAA.Item2 == 0 && strInAGAA.Item3 == 0)
                    {
                        throw new Exception("PartType of cross not found");
                    }
                    connection.Execute("INSERT INTO ElartTecDoc.Article_to_Generic_Article_Allocation (man_article_number, supplier_id, table_id, gen_article_id, Losch_Flag) " +
                        $"VALUES (\"{tecDocNumber}\", {supplierId}, {strInAGAA.Item1}, {strInAGAA.Item2}, {strInAGAA.Item3})");
                    _lastOperationsLogger.Add("Part type was added");
                }
            }
        }

        private void FillSupplierDataAndElartItems()
        {
            labelMessage.Visible = false;
            string supplierSku = textBoxSupplierSKU.Text;
            string tecDocNumber = textBoxNumber.Text;
            string asvelaSKU = textBoxSKU.Text;
            string brandName = comboBoxBrands.SelectedItem.ToString();
            string dinetaSKU = GetDinetaSku();
            string supplier = comboBoxSupplier.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(supplierSku) || string.IsNullOrWhiteSpace(tecDocNumber))
            {
                throw new Exception("SupplierSKU or Number is empty");
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                int supplierId = GetSupplierId(connection, brandName, tecDocName);
                int supplierDataId = connection.Query<int>($"SELECT Id FROM asvela.supplier_data where tecdoc_number = \"{tecDocNumber}\" and supplier_id = {supplierId}").FirstOrDefault();
                if (supplierDataId == 0)
                {
                    connection.Execute("INSERT INTO asvela.supplier_data (sku, asvela_sku, tecdoc_number, supplier_id, brand, date_add, dineta_sku, supplier) " +
                        $"VALUES (\"{supplierSku}\", \"{asvelaSKU}\", \"{tecDocNumber}\", {supplierId}, \"{brandName}\", " +
                        $"\"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}\", \"{dinetaSKU}\", \"{supplier}\")");
                    _lastOperationsLogger.Add("Item was added in asvela.supplier_data");
                }

                int itemId = connection.Query<int>($"Select id from Elart.Items where SKU = \"{asvelaSKU}\"").FirstOrDefault();
                if (itemId == 0)
                {
                    connection.Execute($"Insert into Elart.Items (SKU) values (\"{asvelaSKU}\")");
                    _lastOperationsLogger.Add("Item was added in Elart.Items");
                }
            }
        }

        private int GetSupplierId(MySqlConnection connection, string brandName, string tecDocName)
        {

            int supplierId = connection.Query<int>($"SELECT distinct supplier_id FROM {tecDocName}.Header where brand = \"{brandName}\"").FirstOrDefault();

            if (supplierId == 0)
            {
                throw new Exception("Supplier not found");
            }
            return supplierId;
        }

        private string GetDinetaSku()
        {
            string brandName = comboBoxBrands.SelectedItem.ToString();
            string brandNameForSKU = renamedBrands.ContainsKey(brandName) ? renamedBrands[brandName] : brandName;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string prefix = connection.Query<string>($"SELECT Prefix FROM Elart.DinetaSKUPrefixes where BrandName = \"{brandNameForSKU}\"").FirstOrDefault();
                string result = prefix + textBoxNumber.Text;
                return result.Replace(" ", "").ToUpper();
            }
        }

        private void buttonAddPhotos_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.CurrentDirectory;
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                string sourceFileName;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picureFileInfos.Add(new PictureFileInfo
                    {
                        FullFileName = openFileDialog.FileName,
                        Extention = Path.GetExtension(openFileDialog.FileName)
                    });
                    dataGridViewPictures.Rows.Add(openFileDialog.FileName, "Delete");
                }
            }
        }

        private string CreateFolderName(int supplierId)
        {
            string folder = supplierId.ToString();
            while (folder.Length < 4)
            {
                folder = folder.Insert(0, "0");
            }

            return folder;
        }

        private void dataGridViewPictures_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView && e.ColumnIndex == 1 && e.RowIndex >= 0 && e.RowIndex < picureFileInfos.Count)
            {
                picureFileInfos = picureFileInfos.Where(x => x.FullFileName != (string)(sender as DataGridView).Rows[e.RowIndex].Cells[0].Value).ToList();
                (sender as DataGridView).Rows.Remove((sender as DataGridView).Rows[e.RowIndex]);
            }
            if (sender is DataGridView && e.ColumnIndex == 0 && e.RowIndex >= 0 && e.RowIndex < picureFileInfos.Count)
            {
                string path = (sender as DataGridView)[0, e.RowIndex].Value.ToString();
                pictureBox1.Load(path);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            string tecdocNumber = textBoxTecDocNumberForDelete.Text;

            if (string.IsNullOrWhiteSpace(tecdocNumber))
            {
                _lastOperationsLogger.Add("Error: TechDoc number is required!");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                int referencesCount = connection.Execute($"DELETE FROM ElartTecDoc.Reference_Numbers WHERE man_article_number = \"{tecdocNumber}\"");
                int artToGenArtCount = connection.Execute($"DELETE FROM ElartTecDoc.Article_to_Generic_Article_Allocation WHERE man_article_number = \"{tecdocNumber}\"");
                int artLinkageCount = connection.Execute($"DELETE FROM ElartTecDoc.Article_Linkage WHERE man_article_number = \"{tecdocNumber}\"");
                int artCritCount = connection.Execute($"DELETE FROM ElartTecDoc.Article_Criteria WHERE man_article_number = \"{tecdocNumber}\"");

                _lastOperationsLogger.Add($"Removed {referencesCount} records from ElartTecDoc.Reference_Numbers");
                _lastOperationsLogger.Add($"Removed {artToGenArtCount} records from ElartTecDoc.Article_to_Generic_Article_Allocation");
                _lastOperationsLogger.Add($"Removed {artLinkageCount} records from ElartTecDoc.Article_Linkage");
                _lastOperationsLogger.Add($"Removed {artCritCount} records from ElartTecDoc.Article_Criteria");
            }
        }
    }

    internal class PictureFileInfo
    {
        public string FullFileName { get; set; }
        public string Extention { get; set; }
    }
}
