# KingfisherIT

Disclaimer: This product is not affiliated by _Kingfisher IT Services (UK)_. It's just part of a university business project hosted by _KingfisherIT Services (UK)_.

_KingfisherIT_ is a timesheet system. The purpose of the system is to allow employees log timesheets on tasks/projects they've done for a specific company project. The data logged by the employees is used to work out useful statistical information, such as how long users spent on the project which can be used to calculate project cost.

The system has two tiers, a desktop client written in C# and a web panel written in PHP using the Laravel framework. The web panel was designed by https://github.com/callumthomson. The web panel is for project managers to access. The web panel had designed Not only was there a web panel accessible by different users of the system, but there was a web API designed to aid the client side of the program with authentication and submitting data.

### Client 
C#

<img src="http://i.imgur.com/N3NAMco.png">
<br>
The employees use the desktop application to login onto the system.

<kbd>
  <img src="http://i.imgur.com/pAbsD5a.png?1">
</kbd>
<br>
Once a user is logged in, they are presented with all available projects and tasks within each project

<kbd>
  <img src="http://i.imgur.com/X38vfLS.png?1">
</kbd>
<br>
When the user selects a project and task, they can then submit a timesheet which has details on the specific task they've done

<br>
The data is then submitted to the remote database via a web API

### Web panel
___

<img src="http://i.imgur.com/pQiqQYG.png?1">
<br>
The project manager logs in to the web panel (regular employees cannot login via this web panel)
___
<br>
<br>
<img src="http://i.imgur.com/riVlaGI.png">
<img src="http://i.imgur.com/2mFCPJ4.png">
<br>
The project manager can then click on projects they manage to view the timesheets submitted for that activity
<br>
<br>
___
<img src="http://i.imgur.com/zNqdLvl.png">
Project managers now have the ability to accept or reject timesheets submitted by employees.
<br>
<br>
