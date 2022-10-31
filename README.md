# CaseStudy


## Test Case 1

### Configure Chrome Web Driver


1- Use the chrome driver nuget package

2- On your Solution name, right click Properties

3-  On Build Tab Add the below:

    Conditional compilation symbols: _PUBLISH_CHROMEDRIVER

    Output Path: bin\Debug\

4- Rebuild solution and you should see chromedriver.exe in bin\debug

5- Run the application

6- Check the log file in bin\Debug folder (stdout)

## Test Case 2



