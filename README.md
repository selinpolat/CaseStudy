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

Right click on CaseMockApı project then click Run Tests

1- In Set Up attribute server is created via WireMockServer using 9090 port

2-CreateProdutsStub is created GET products endpoint with given example json

3- In Test attribute via ResClient the request is sent to localhost:9090 
    EXPECTED:It is expected to given exaple_produc.json data

4- Assertion are controlled

5-TearDown terminates the server




