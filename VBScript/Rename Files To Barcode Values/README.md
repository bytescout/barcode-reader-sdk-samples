## How to rename files to barcode values in VBScript using ByteScout BarCode Reader SDK

### How to rename files to barcode values in VBScript

Learn how to rename files to barcode values in VBScript with this source code sample. ByteScout BarCode Reader SDK can rename files to barcode values. It can be used from VBScript. ByteScout BarCode Reader SDK is the SDK for reading of barcodes from PDF, images and live camera or video. Almost every common type like Code 39, Code 128, GS1, UPC, QR Code, Datamatrix, PDF417 and many others are supported. Supports noisy and defective images and docs. Includes optional documents splitter and merger for pdf and tiff based on found barcodess. Batch mode is supported for superior performance using multiple threads. Decoded values are easily exported to JSON, CSV, XML and to custom format.

You will save a lot of time on writing and testing code as you may just take the VBScript code from ByteScout BarCode Reader SDK for rename files to barcode values below and use it in your application. In your VBScript project or application you may simply copy & paste the code and then run your app! Enjoy writing a code with ready-to-use sample VBScript codes.

Trial version of ByteScout BarCode Reader SDK is available for free. Source code samples are included to help you with your VBScript app.

## REQUEST FREE TECH SUPPORT

[Click here to get in touch](https://bytescout.zendesk.com/hc/en-us/requests/new?subject=ByteScout%20BarCode%20Reader%20SDK%20Question)

or just send email to [support@bytescout.com](mailto:support@bytescout.com?subject=ByteScout%20BarCode%20Reader%20SDK%20Question) 

## ON-PREMISE OFFLINE SDK 

[Get Your 60 Day Free Trial](https://bytescout.com/download/web-installer?utm_source=github-readme)
[Explore SDK Docs](https://bytescout.com/documentation/index.html?utm_source=github-readme)
[Sign Up For Online Training](https://academy.bytescout.com/)


## ON-DEMAND REST WEB API

[Get your API key](https://pdf.co/documentation/api?utm_source=github-readme)
[Explore Web API Documentation](https://pdf.co/documentation/api?utm_source=github-readme)
[Explore Web API Samples](https://github.com/bytescout/ByteScout-SDK-SourceCode/tree/master/PDF.co%20Web%20API)

## VIDEO REVIEW

[https://www.youtube.com/watch?v=EARSPJFIJMU](https://www.youtube.com/watch?v=EARSPJFIJMU)




<!-- code block begin -->

##### ****RenameFilesToBarcodeValues.vbs:**
    
```
if WScript.Arguments.Count < 2 Then
 MsgBox "Run with the folder path as the argument" & vbCRLF & vbCRLF & "RenameFiles.vbs InputFolder\ OutputFolder\"
 WScript.Quit 0
End If

Set objFSO = CreateObject("Scripting.FileSystemObject")

' define allowed input images extensions
inputImagesExtensions = "JPG,JPEG,PNG,BMP,PDF,TIF"

' make sure they all are upper cases
inputImagesExtensions = UCASE(inputImagesExtensions)


Set bc = CreateObject("Bytescout.BarCodeReader.Reader")

' Set barcode types to find:
bc.BarcodeTypesToFind.Code39 = True
bc.BarcodeTypesToFind.QRCode = True
bc.BarcodeTypesToFind.PDF417 = True

Set objinputFolder = objFSO.GetFolder(WScript.Arguments(0))

' output folder
set objOutputFolder = objFSO.GetFolder(WScript.Arguments(1))

Call ShowSubfolders (objinputFolder)

WScript.Quit 0

Sub ShowSubFolders(fFolder)
    Set objFolder = objFSO.GetFolder(fFolder.Path)
    Set colFiles = objFolder.Files
    For Each objFile in colFiles
	' check if allowed extension
        If inStr(inputImagesExtensions, UCase(objFSO.GetExtensionName(objFile.name)))>0 Then

	    ' read barcode from filename
	    WScript.Echo "Reading from: " & objFile.Path 
            bc.ReadFromFile objFile.Path 

	    ' getting the sub folder path
	    outputSubFolder = Replace(objFile.Path, objinputFolder.Path, "")
	    outputSubFolder = Replace(outputSubFolder, objFile.Name, "")
		
            ' rename the file to the value of the very first barcode found on this image or pdf
	    newFileName = bc.GetFoundBarcodeValue(0) & "." & objFSO.GetExtensionName(objFile.name)

	    ' replace some special characters as they may not be allowed for use in filename
            newFileName = Replace(newFileName, "<", "_")
            newFileName = Replace(newFileName, ">", "_")

	    ' first check if output subfolder exists
 	    if Not objFSO.FolderExists (objOutputFolder.Path & outputSubFolder) Then
		objFSO.CreateFolder objOutputFolder.Path & outputSubFolder
	    End If

	    WScript.Echo "Copying and renaming " & objFile.path & " into " & objOutputFolder.Path & outputSubFolder & newFileName

	    ' copying the source file into output folder with new filename based on the barcode value
	    objFSO.CopyFile objFile.path, objOutputFolder.Path & outputSubFolder & newFileName



        End If
    Next

    For Each Subfolder in fFolder.SubFolders
        ShowSubFolders(Subfolder)
    Next
End Sub


```

<!-- code block end -->    

<!-- code block begin -->

##### ****RunRenaming.bat:**
    
```
REM running from the command line
cscript.exe RenameFilesToBarcodeValues.vbs "input" "output"
pause
```

<!-- code block end -->