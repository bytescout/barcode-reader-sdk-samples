'*******************************************************************************************'
'                                                                                           '
' Download Free Evaluation Version From:     https://bytescout.com/download/web-installer   '
'                                                                                           '
' Also available as Web API! Free Trial Sign Up: https://secure.bytescout.com/users/sign_up '
'                                                                                           '
' Copyright © 2017-2018 ByteScout Inc. All rights reserved.                                 '
' http://www.bytescout.com                                                                  '
'                                                                                           '
'*******************************************************************************************'


Imports Bytescout.BarCodeReader

Class Program
	Friend Shared Sub Main(args As String())

        Dim reader As New Reader()
        reader.RegistrationName = "demo"
        reader.RegistrationKey = "demo"

        ' Limit search to 1-dimensional barcodes only (exclude 2D barcodes to speed up the processing).
        ' Change to barcodeReader.BarcodeTypesToFind.SetAll() to scan for all supported 1D and 2D barcode types
        ' or select specific type, e.g. barcodeReader.BarcodeTypesToFind.PDF417 = True
        reader.BarcodeTypesToFind.All1D = True

        ' Input filename
        Dim fileName As String = "multipage.tif"

        ' Pages from which barcodes to be fetched
        Dim readFromPages() As Int32 = {1, 2, 4, 6}

        For Each pageNo As Int32 In readFromPages

            Console.WriteLine(Environment.NewLine + "Reading barcodes from TIFF page {0}...", pageNo)

            ' Decoding barcodes from TIFF on page-by-page basis instead of reading whole page
            Dim barcodes As FoundBarcode() = reader.ReadFrom(fileName, (pageNo - 1))

            ' Found results
            For Each barcode As FoundBarcode In barcodes
                Console.WriteLine("Found Barcode, Type: '{0}', Value: '{1}', Position: {2}", barcode.Type, barcode.Value, barcode.Rect)
            Next

        Next

        ' Cleanup
        reader.Dispose()

        Console.WriteLine()
        Console.WriteLine("Press any key to continue.")
        Console.ReadKey()
	End Sub
End Class
