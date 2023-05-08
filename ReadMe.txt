Marc Sahler

This project is a simple WPF program where you can add a Highscore to a CSV File and u can also look at all the Highscores in a seperate Page where they are all inside a DataGrid.

You can add a Highscore in The AddHighscorePage in which you have to fill in some textboxes with Username, Video Game Name, Highscore, and a comment, ther is also a Datepicker 
where you need to pick a Date in the past or today. All of the written values will be Validaten and if wrong there will be a correct Error Message.

After adding a Highscore and Validating the Highscore they will then be added to a CSV File with the AddScoreToCSV() Method.

There is also a Page where at the initialization of the Page all of the Highscores will be read from the CSV and shown in a Datagrid in the GUI.
