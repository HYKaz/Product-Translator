/***** 786 66 SWT 92 S 110 135 118 128 69 133 145 ASA

Project: Product Translator
Sub Component: DataMatrix/Barcode Generator.
Programmer: Syed Hasan Yasar Kazmi.
Description: this is part of COMIT .Net Course final project. 
This software generates DataMatrix/Barcodes, to be used with Product Translator.
Credits: This software uses following 3rd party :
1. BarcodeLib.dll
2. DataMatrix.net.dll
Source:  By David Vanson on CodePrject.com
 *  * *****************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KBarCodeGen
{
    public partial class Form1 : Form
    {

        // Declerations -------------------------

            //Linear BarCode [Linear BarCode was discared during project research phase and data matrix was chosen.]
       private BarcodeLib.Barcode LinearEncoder;
       private Image Linearimg;
       private Bitmap Linearbitmap;
       public Bitmap barcodeImage;
       

        //Save Image
        private SaveFileDialog SFD;
        private Bitmap CodeBitmap;

        // Data Matrix

        private DataMatrix.net.DmtxImageEncoder DataEncoder;
        private DataMatrix.net.DmtxImageEncoderOptions DataEncodeOptions;
        private Image Dataimg;
        private Bitmap Databitmap;
        private Color DM_forecolour = Color.Black;
        private Color DM_backcolour = Color.White;
        
        private Font SelectedFont = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Regular);
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Init();

         }

        private void Init()
        {
            // Reset All

            clr();
            Cbo_D_Size.SelectedIndex = 5;
            Cbo_D_Module.SelectedIndex = 0;
            Cbo_D_Scheme.SelectedIndex = 7;
            Cbo_D_Margin.SelectedIndex = 0;
        }

        private void clr()
        {
            // Clear Datainput Textbox
            Txt_InputData.Clear();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            // Clear Text from txt1 textbox. 
            clr();

             }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            // Generate Barcode

            // GenerateBarcode_Linear(Txt_InputData.Text);
            GenerateBarcode_DataMatrix(Txt_InputData.Text);
            this.DialogResult = DialogResult.OK;

        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            Txt_InputData.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            Txt_InputData.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            Txt_InputData.Paste();
        }

        private void SaveImage()
        { 
            
            // Save The Barcode Image 

            SFD = new SaveFileDialog();
            SFD.Filter = "Bmp (*.bmp) |*.bmp | Jpeg (*.jpg)|*.jpg | PNG (*.png)|*.png | SVG (*.svg)|*.svg | TIFF (*.tiff)|*.tiff";
            SFD.FilterIndex = 2;
           
            CodeBitmap = new Bitmap(barcodeImage);


            if (SFD.ShowDialog() == DialogResult.OK)
            {
                CodeBitmap.Save(SFD.FileName);
            }

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveImage();
        }


        // Generate Function
        public void GenerateBarcode_Linear(string inputData)
        {
            LinearEncoder = new BarcodeLib.Barcode();
            LinearEncoder.EncodedType = BarcodeLib.TYPE.UPCA;
            LinearEncoder.AlternateLabel = Txt_InputData.Text;
            // TextBox1.Text = LinearEncoder.Country_Assigning_Manufacturer_Code;
            LinearEncoder.BackColor = Color.White;
            LinearEncoder.ForeColor = Color.Black;
            LinearEncoder.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;
            LinearEncoder.IncludeLabel = false;
                
                // 
                try
                {
                
                LinearEncoder.LabelFont = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Regular);
                Linearimg = LinearEncoder.Encode((BarcodeLib.TYPE)34, inputData);//, Color.Black, Color.White, 200, 200);

                Linearbitmap = new Bitmap(Linearimg);
                   
                 barcodeImage = Linearbitmap;
                             
                PicBox1.Image = barcodeImage;

                }

                catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                                    }
     
        }

        private void GenerateBarcode_DataMatrix(string inputData)
        {

            if (Txt_InputData.Text.Length <= 0) { 
                MessageBox.Show("You must Include the data to be Encoded.");
            return;
            }
            // 
            try // Encode
                {
                    DataEncoder = new DataMatrix.net.DmtxImageEncoder();
                    DataEncodeOptions = new DataMatrix.net.DmtxImageEncoderOptions();
                    // Options-----------------------------------
                    // size options
                    if (Cbo_D_Size.SelectedIndex == 0)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol8x18;
                    else if (Cbo_D_Size.SelectedIndex == 1)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol8x32;
                    else if (Cbo_D_Size.SelectedIndex == 2)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol10x10;
                    else if (Cbo_D_Size.SelectedIndex == 3)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol12x12;
                    else if (Cbo_D_Size.SelectedIndex == 4)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol12x26;
                    else if (Cbo_D_Size.SelectedIndex == 5)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol12x36;
                    else if (Cbo_D_Size.SelectedIndex == 6)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol14x14;
                    else if (Cbo_D_Size.SelectedIndex == 7)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol16x16;
                    else if (Cbo_D_Size.SelectedIndex == 8)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol16x36;
                    else if (Cbo_D_Size.SelectedIndex == 9)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol16x48;
                    else if (Cbo_D_Size.SelectedIndex == 10)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol18x18;
                    else if (Cbo_D_Size.SelectedIndex == 11)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol20x20;
                    else if (Cbo_D_Size.SelectedIndex == 12)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol22x22;
                    else if (Cbo_D_Size.SelectedIndex == 13)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol24x24;
                    else if (Cbo_D_Size.SelectedIndex == 14)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol26x26;
                    else if (Cbo_D_Size.SelectedIndex == 15)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol32x32;
                    else if (Cbo_D_Size.SelectedIndex == 16)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol36x36;
                    else if (Cbo_D_Size.SelectedIndex == 17)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol40x40;
                    else if (Cbo_D_Size.SelectedIndex == 18)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol44x44;
                    else if (Cbo_D_Size.SelectedIndex == 19)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol48x48;
                    else if (Cbo_D_Size.SelectedIndex == 20)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol52x52;
                    else if (Cbo_D_Size.SelectedIndex == 21)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol64x64;
                    else if (Cbo_D_Size.SelectedIndex == 22)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol72x72;
                    else if (Cbo_D_Size.SelectedIndex == 23)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol80x80;
                    else if (Cbo_D_Size.SelectedIndex == 24)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol88x88;
                    else if (Cbo_D_Size.SelectedIndex == 25)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol96x96;
                    else if (Cbo_D_Size.SelectedIndex == 26)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbolRectAuto;
                    else if (Cbo_D_Size.SelectedIndex == 27)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbolShapeAuto;
                    else if (Cbo_D_Size.SelectedIndex == 28)
                        DataEncodeOptions.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbolSquareAuto;
                    // 
                    // 
                    // scheme options
                    if (Cbo_D_Scheme.SelectedIndex == 0)
                        DataEncodeOptions.Scheme = DataMatrix.net.DmtxScheme.DmtxSchemeAscii;
                    else if (Cbo_D_Size.SelectedIndex == 1)
                        DataEncodeOptions.Scheme = DataMatrix.net.DmtxScheme.DmtxSchemeAsciiGS1;
                    else if (Cbo_D_Size.SelectedIndex == 2)
                        DataEncodeOptions.Scheme = DataMatrix.net.DmtxScheme.DmtxSchemeAutoBest;
                    else if (Cbo_D_Size.SelectedIndex == 3)
                        DataEncodeOptions.Scheme = DataMatrix.net.DmtxScheme.DmtxSchemeAutoFast;
                    else if (Cbo_D_Size.SelectedIndex == 4)
                        DataEncodeOptions.Scheme = DataMatrix.net.DmtxScheme.DmtxSchemeBase256;
                    else if (Cbo_D_Size.SelectedIndex == 5)
                        DataEncodeOptions.Scheme = DataMatrix.net.DmtxScheme.DmtxSchemeC40;
                    else if (Cbo_D_Size.SelectedIndex == 6)
                        DataEncodeOptions.Scheme = DataMatrix.net.DmtxScheme.DmtxSchemeEdifact;
                    else if (Cbo_D_Size.SelectedIndex == 7)
                        DataEncodeOptions.Scheme = DataMatrix.net.DmtxScheme.DmtxSchemeText;
                    else if (Cbo_D_Size.SelectedIndex == 8)
                        DataEncodeOptions.Scheme = DataMatrix.net.DmtxScheme.DmtxSchemeX12;
                    // 
                    // module size options
                    if (Cbo_D_Module.SelectedIndex == 0)
                        DataEncodeOptions.ModuleSize = 1;
                    else if (Cbo_D_Module.SelectedIndex == 1)
                        DataEncodeOptions.ModuleSize = 2;
                    else if (Cbo_D_Module.SelectedIndex == 2)
                        DataEncodeOptions.ModuleSize = 3;
                    else if (Cbo_D_Module.SelectedIndex == 3)
                        DataEncodeOptions.ModuleSize = 4;
                    else if (Cbo_D_Module.SelectedIndex == 4)
                        DataEncodeOptions.ModuleSize = 5;
                    else if (Cbo_D_Module.SelectedIndex == 5)
                        DataEncodeOptions.ModuleSize = 6;
                    else if (Cbo_D_Module.SelectedIndex == 6)
                        DataEncodeOptions.ModuleSize = 7;
                    else if (Cbo_D_Module.SelectedIndex == 7)
                        DataEncodeOptions.ModuleSize = 8;
                    else if (Cbo_D_Module.SelectedIndex == 8)
                        DataEncodeOptions.ModuleSize = 9;
                    else if (Cbo_D_Module.SelectedIndex == 9)
                        DataEncodeOptions.ModuleSize = 10;
                    // 
                    // margin size options
                    if (Cbo_D_Margin.SelectedIndex == 0)
                        DataEncodeOptions.MarginSize = 1;
                    else if (Cbo_D_Margin.SelectedIndex == 1)
                        DataEncodeOptions.MarginSize = 2;
                    else if (Cbo_D_Margin.SelectedIndex == 2)
                        DataEncodeOptions.MarginSize = 3;
                    else if (Cbo_D_Margin.SelectedIndex == 3)
                        DataEncodeOptions.MarginSize = 4;
                    else if (Cbo_D_Margin.SelectedIndex == 4)
                        DataEncodeOptions.MarginSize = 5;
                    // 
                    DataEncodeOptions.ForeColor = DM_forecolour;
                    DataEncodeOptions.BackColor = DM_backcolour;
                    // ---------------------------
                    // 
                    Dataimg = DataEncoder.EncodeImage(inputData, DataEncodeOptions);
                    Databitmap = new Bitmap(Dataimg);
                    barcodeImage = Databitmap;
                    //Label12.Text = "Hashcode: " + DataEncoder.GetHashCode;
                    
                
                PicBox1.Image = barcodeImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
               
            }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        //____________________________________________

    }
}
