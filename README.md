# configCatTryout

The application is a mock-up web application for a user management system, where the admin can add new users, view users and filter users (in the future also delete and update).
Basically, once in the application you can view/filter or add users.

Running:

- Clone repository.
- Open the source code project in Visual Studio and run the application.
- The application opens in a new browser tab.
- Since the database is offline, it won't actually display or add the users, but you can navigate through its pages.

I used a feature flag for changing the UI of the application. The idea would be that men and women have different UIs or that you can simply change the UI based 
on the value of the feature flag. At the moment, there is a "pretty" pink UI and a simple grey one.

Feature flag variable can be found under WebApplication3 -> Controllers -> HomeController. 
