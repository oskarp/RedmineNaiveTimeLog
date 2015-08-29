# Naive Redmine Time Log

NRTL is a tiny tool to help you log time for projects tracked in Redmine. This project is a proof of concept to explore the Redmine API and WPF. It is not intended to be used in production or perhaps at all in its current state...

It does however provide three things.

* Examples of how to work with the C# Redmine api wrapper
* Rudimentary ability to track time for your projects.
* A platform for refactoring. 


My intention is to explore MVVM using this project as a basis for refactoring. However, if you actually find something that offends you to the point of it needing to be fixed please report it in the tracker. 

## Usage

On first run, go to settings and define the URL to your Redmine installation. Your list of issues should show up and you can start tracking time by pressing the "start tracking" button while having the active issue selected.

## Requirements
* A version of Redmine that has a REST API, and has that enabled.
* Windows with .Net. (Tested with 7 and above)

## Screenshot

![App UI](http://oskarp.github.io/images/rntl_ui.png)

## Dependencies

[Redmine-net-api](https://github.com/zapadi/redmine-net-api) 
