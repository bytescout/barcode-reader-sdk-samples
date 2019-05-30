//*******************************************************************************************//
//                                                                                           //
// Download Free Evaluation Version From: https://bytescout.com/download/web-installer       //
//                                                                                           //
// Also available as Web API! Get Your Free API Key: https://app.pdf.co/signup               //
//                                                                                           //
// Copyright © 2017-2019 ByteScout, Inc. All rights reserved.                                //
// https://www.bytescout.com                                                                 //
// https://pdf.co                                                                            //
//                                                                                           //
//*******************************************************************************************//


using System;
using System.IO;
using Bytescout.BarCodeReader;

namespace CommonExample
{
	class Program
	{
		const string ImageFile = "Barcode.jpg";

		static void Main()
		{
			Console.WriteLine("Reading barcode(s) from image {0}", Path.GetFullPath(ImageFile));

			Reader reader = new Reader();
			reader.RegistrationName = "demo";
			reader.RegistrationKey = "demo";

			// Set barcode type to find
			reader.BarcodeTypesToFind.All = true;
			// We recommend to use specific barcode types to avoid false positives, e.g.:
			// reader.BarcodeTypesToFind.QRCode = true;
			// reader.BarcodeTypesToFind.Code39 = true;

			// Read barcodes
			FoundBarcode[] barcodes = reader.ReadFrom(ImageFile);

			foreach (FoundBarcode barcode in barcodes)
			{
				Console.WriteLine("Found barcode with type '{0}' and value '{1}'", barcode.Type, barcode.Value);
			}

			// Cleanup
			reader.Dispose();
			
			Console.WriteLine("Press any key to exit..");
			Console.ReadKey();
		}
	}
}
