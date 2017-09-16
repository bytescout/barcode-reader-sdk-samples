//****************************************************************************//
//                                                                            //
// Download evaluation version: https://bytescout.com/download/web-installer  //
//                                                                            //
// Signup Cloud API free trial: https://secure.bytescout.com/users/sign_up    //
//                                                                            //
// Copyright © 2017 ByteScout Inc. All rights reserved.                       //
// http://www.bytescout.com                                                   //
//                                                                            //
//****************************************************************************//


using System;
using Bytescout.BarCodeReader;

namespace ImagePreprocessingFilters
{
    /// <summary>
    /// This exmaple demonstrates the use of image filters to improve the decoding or speed.
    /// </summary>
    class Program
    {
        static void Main()
        {
            using (Reader reader = new Reader("demo", "demo"))
            {
                // Set barcode type to find
                reader.BarcodeTypesToFind.Code128 = true;


                // WORKING WITH LOW CONTRAST BARCODE IMAGES

                // Add the contrast adjustment for the low contrast image
                reader.ImagePreprocessingFilters.AddContrast(40);

                Console.WriteLine("Image {0}", "low-contrast-barcode.png");
                
                FoundBarcode[] barcodes = reader.ReadFrom("low-contrast-barcode.png");

                if (barcodes.Length == 0)
                    Console.WriteLine("No barcode found!");
                else 
                    foreach (FoundBarcode barcode in barcodes)
                        Console.WriteLine("Found barcode {0} with value '{1}'", barcode.Type, barcode.Value);

                reader.ImagePreprocessingFilters.Clear();
                Console.WriteLine();


                // WORKING WITH NOISY BARCODE IMAGES

                // Add the median filter to lower the noise
                reader.ImagePreprocessingFilters.AddMedian();

                Console.WriteLine("Image {0}", "noisy-barcode.png");

                barcodes = reader.ReadFrom("noisy-barcode.png");

                if (barcodes.Length == 0)
                    Console.WriteLine("No barcode found!");
                else
                    foreach (FoundBarcode barcode in barcodes)
                        Console.WriteLine("Found barcode {0} with value '{1}'", barcode.Type, barcode.Value);

                reader.ImagePreprocessingFilters.Clear();
                Console.WriteLine();


                // WORKING WITH DENSE AND ILLEGIBLE BARCODES

                // Add the scale filter to enlarge the barcode to make gaps between bars more distinguishable
                reader.ImagePreprocessingFilters.AddScale(2); // enlarge twice

                Console.WriteLine("Image {0}", "too-dense-barcode.png");

                barcodes = reader.ReadFrom("too-dense-barcode.png");

                if (barcodes.Length == 0)
                    Console.WriteLine("No barcode found!");
                else
                    foreach (FoundBarcode barcode in barcodes)
                        Console.WriteLine("Found barcode {0} with value '{1}'", barcode.Type, barcode.Value);

                reader.ImagePreprocessingFilters.Clear();
                Console.WriteLine();
                
                
                // REMOVE EMPTY MARGINS FROM IMAGE TO SPEED UP THE PROCESSING

                // Add the crop filter to cut off empty margins from the image.
                // This will not improve the recognition quality but may speed up the processing 
                // if you enabled multiple barcode types to search. 
                reader.ImagePreprocessingFilters.AddCropDark();

                Console.WriteLine("Image {0}", "barcode-with-large-margins.png");

                barcodes = reader.ReadFrom("barcode-with-large-margins.png");

                if (barcodes.Length == 0)
                    Console.WriteLine("No barcode found!");
                else
                    foreach (FoundBarcode barcode in barcodes)
                        Console.WriteLine("Found barcode {0} with value '{1}'", barcode.Type, barcode.Value);

                reader.ImagePreprocessingFilters.Clear();
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to exit..");
            Console.ReadKey();
        }
    }
}
