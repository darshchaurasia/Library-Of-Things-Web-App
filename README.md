# Library of Things

A service-oriented ASP .NET Web Application that lets community members borrow everyday household items rather than purchase them.

---

## Features

- **Public Landing**  
  - Light/dark theme toggle (Session-state + App_Themes)  
  - Service Directory listing all components & TryIt links  

- **Member Dashboard**  
  - Self-registration (Register.aspx) with CAPTCHA handler  
  - Forms-auth login (Login.aspx) with “Remember Me” cookie  
  - Browse or keyword-search inventory (SearchService.svc)  
  - Add items to a session-state cart, select return dates  
  - Checkout via LoanService.svc, compute late fees (FeeCalcLibrary DLL)  
  - View “My Borrowed Items” with due dates (ScheduleService.svc) and return  

- **Staff Dashboard**  
  - Login as default **TA / Cse445!** or any promoted user  
  - **User Management:** promote/demote/delete users (Accounts.xml via AuthHelper)  
  - **Item Management:** create/edit/delete items (Items.xml via ItemRepository)  
  - **Borrowed Items:** view & mark returns, calculate late fees  

- **Developer/Testability**  
  - TryIt pages for each service & component (TryIt_*.aspx)  
  - Clear “How to Test” instructions on landing page  

---

## Prerequisites

- Windows with IIS or IIS Express  
- .NET Framework 4.7.2 (or higher)  
- Visual Studio 2022 (or 2019) with **ASP .NET Web Application** workload  
- SQL Server not required (all data stored in XML under `App_Data`)  

---

## Setup & Run

1. **Clone** this repository  
   ```bash
   git clone https://github.com/darshchaurasia/Library-Of-Things-Web-App
   cd LibraryOfThings

---

## Project Structure

/App_Themes/
  /light/…         ← CSS for light mode
  /dark/…          ← CSS for dark mode

/Controls/
  LoginPanel.ascx  ← login + CAPTCHA + “Remember Me” control

/Handlers/
  Captcha.ashx     ← generates CAPTCHA image

/Services/
  ScheduleService.svc
  LoanService.svc
  SearchService.svc

/Models/
  Item.cs
  ItemRepository.cs

/Helpers/
  AuthHelper.cs    ← register/validate/promote/demote/delete users

/App_Data/
  Accounts.xml     ← user store
  Items.xml        ← inventory store
  ErrorLog.xml     ← (optional) global error log

/TryIt_*.aspx      ← pages to test each component/service

Default.aspx       ← landing + service directory  
Member.aspx        ← member dashboard  
Staff.aspx         ← staff dashboard  
Cart.aspx          ← session-state cart checkout  
Register.aspx      ← user registration  
Login.aspx         ← login page  

Global.asax        ← global event handlers  

FeeCalcLibrary/    ← DLL with ComputeLateFee & HashPassword


