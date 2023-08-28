# Dynamo

## Objective: Create a web application that allows clients to upload XML files. The application should process
the files in the backend, converting them to JSON, and then save them in a specified directory. The
application should be able to handle multiple requests concurrently.

## Requirements:
- [x] File Upload: Develop an endpoint for uploading XML files. The endpoint should accept a POST
request with a file attachment and a filename parameter.
- [x] File Conversion: After a file is uploaded, the application should convert the XML data to JSON.
You may use any libraries or tools you're comfortable with to achieve this.
- [x] File System Interaction: Save the converted JSON file in a specified directory. The filename
should be the same as the original file but with a. json extension.
- [x] Concurrency: The application should be able to process multiple files concurrently. If two or
more files are uploaded at the same time, the application should process them without waiting
for the previous file to finish.
- [x] Error Handling: The application should gracefully handle any errors, including invalid XML files,
file system errors, or server errors. In the case of an error, the application should return a
meaningful error message to the client.
- [ ] Testing: Write unit tests for your code, demonstrating that it functions as expected under
different scenarios.
- [x] Documentation: Write a brief document outlining how to use your API.

## Dev notes
### Documentation is part of the Swagger. Can be enriched aditionaly.
### Tests are no done yet.
