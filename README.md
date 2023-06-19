# CV Management app (ASP .NET 6)
This is a smol university project i made in 3 days. So the UI is quite rough heh, i just wanted to get the functionality done and study some other stuff.

## Functionality 
- Create a CV using predefined fields 
- Browse all created CVs
  - Inspect the CV
  - Edit the CV
  - Delete the CV
  - Download the CV as a PDF

### Backend Functionality
- Database using MySQL
- Saving and deleting images from the project
- Client-side validation
- Server-side validation

## Pages
- Home
- Send a CV
- Browse CVs
- Download CVs

(Now i know i could have made the Browse & Download pages in a single page, but i just wanted to try scaffolding(Download) and doing it manually(Browse))

## Stuff that can be improved
- Dynamic checkbox list. _I could not for some reason list the checkboxes from a list and bind them at the same time. It just didnt work_
- UI. _i should be executed for this UI_

# Installation Requirements
- Visual Studio: https://visualstudio.microsoft.com/vs/community/
- WAMP: https://www.wampserver.com/en/download-wampserver-64bits/
  - or XAMPP: https://www.apachefriends.org/download.html  

Make sure phpmyadmin has a user with the following credentials
- Username: root
- Password: none _(and i mean dont give it a password, not the word none)_

Run the project using this command
```
dotnet run
```

# Screenshots
### Welcome Page
![image](https://github.com/Atomic-Potato/ASP-.NET6-CV-Manager/assets/55362397/271093ed-26fe-4e51-a872-8521f9a29a9f)
### Download Page
_(Pretty much looks the same as the Browse page)_
![image](https://github.com/Atomic-Potato/ASP-.NET6-CV-Manager/assets/55362397/98e63652-2f25-48ee-8d3a-91600071ac68)
### Send Page
_(This page is also used to edit the CV from the Browse page)_
![image](https://github.com/Atomic-Potato/ASP-.NET6-CV-Manager/assets/55362397/a835e8ef-2788-4337-977a-22459a5121b5)
### Summary Page
_(If you download the CV as a PDF and open it up, it will look similar to this)_
![image](https://github.com/Atomic-Potato/ASP-.NET6-CV-Manager/assets/55362397/e48a35bd-f982-453c-a3a0-706362030085)
### Confirm Delete Page
![image](https://github.com/Atomic-Potato/ASP-.NET6-CV-Manager/assets/55362397/532cd56b-8fcd-4651-a3bd-ae9b6204b12f)

