:: (!) If you are getting '(403) Forbidden' error please ensure you have set the correct API_KEY

@echo off

:: Path of the cURL executable
set CURL="curl.exe"

:: The authentication key (API Key).
:: Get your own by registering at https://secure.bytescout.com/users/sign_up
set API_KEY=***********************************

:: Direct URL of source file to search barcodes in.
set SOURCE_FILE_URL=https://s3-us-west-2.amazonaws.com/bytescout-com/files/demo-files/cloud-api/barcode-reader/sample.pdf
:: Comma-separated list of barcode types to search. 
:: See valid barcode types in the documentation https://secure.bytescout.com/cloudapi.html#api-Default-barcodeReadFromUrlGet
set BARCODE_TYPES=Code128,Code39,Interleaved2of5,EAN13
:: Comma-separated list of page indices (or ranges) to process. Leave empty for all pages. Example: '0,2-5,7-'.
set PAGES=

:: Prepare URL for `Barcode Reader` API endpoint
set QUERY="https://bytescout.io/v1/barcode/read/from/url?types=%BARCODE_TYPES%&pages=%PAGES%&url=%SOURCE_FILE_URL%"

:: Perform request and save response to a file
%CURL% -# -X GET -H "x-api-key: %API_KEY%" %QUERY% >response.json

:: Display the response
type response.json

:: Use any convenient way to parse JSON response and get information about decoded barcodes.


echo.
pause