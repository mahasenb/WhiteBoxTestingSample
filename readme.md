# White-box testing sample application

This repository contains a sample application to demonstrate how Dev - QE collaboration could drastically cut down on both Dev and QE effort, while achieving better ROI of test cases.

## TargetApplication - ASP .NET Core 2.1 MVC Website

This is the target of the tests. Which contains a simple page to capture information to perform an calculation, and upon submission, render a page with the result.

## TargetLibrary - .NET Core 2.1 Class Library

This contains the business logic for the above application.

## TargetApplication.Tests - MSTests (.NET Core) test library

Contains Selenium Webdriver based test suite for testing the TargetApplication and TargetLibrary through the UI.

## runCoverage.bat file

The batch file which executes IIS Express through OpenCover, serving the TargetApplication. When IIS is closed, it will generate a coverage report using ReportGenerator.
This file needs to be edited to update the paths for executable files appropriately.

## License

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.