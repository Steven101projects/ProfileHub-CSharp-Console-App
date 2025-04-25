# ProfileHubApp 📝

A bite-sized console app that lets you **Add, View, Update & Delete** personal profiles—CRUD without the crust.

---

## Quick Tour
1. **Run** the program → snappy ASCII menu appears.  
2. **Pick** an option (Add / View / Update / Delete).  
3. **Profiles** live on in `profiles.txt`—close the app without losing a thing.

---

## Anatomy in 3 Nibbles
- **Menu**  
  - `ShowMenu()` 🎛️ – draws the menu  
  - `AccessMenu()` 🔑 – opens the chosen door  

- **Profile**  
  - `Name` = `firstName + lastName`  
  - `Age` (input) → `YearOfBirth = Now.Year - Age`  
  - `Id` = random 100-999  

- **ProfData** – the file-whisperer  
  - `Add`, `Show`, `Save`, `Load`, `View(id)`, `Update(id)`, `Delete(id)`

---

## Why You’ll Love It
- **Plain-text persistence** – no database drama  
- **Instant uniqueness** – random IDs keep clashes away  
- **CLI simplicity** – launches in seconds, no GUI tantrums

Clone → build → type away. **Profile like a pro!** 🚀
