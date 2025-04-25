# ProfileHubApp 📝🎉

**A snappy little console companion for creating, browsing, and curating personal profiles — because everyone deserves a neat bio!**

---

## 🚀 What You Can Do

| Action | One‑liner |
| ------ | -------- |
| **Add**    | Create a brand‑new profile in seconds. |
| **View**   | Peek at every saved profile or zoom in on one by ID. |
| **Update** | Give a profile a fresh haircut (or just fix a typo). |
| **Delete** | Marie‑Kondo any profile that no longer sparks joy. |

> "Enjoy!" – ProfileHubApp, probably

---

## 🛠️ Under the Hood

ProfileHubApp keeps things intentionally simple with **three core classes**:

| Class | Purpose | Key Members |
|-------|---------|-------------|
| **`Menu`** | Presents choices and routes user input. | `ShowMenu()` • `AccessMenu()` |
| **`Profile`** | Models a single person’s info. | `Name` (first + last) • `Age` • `YearOfBirth` *(currentYear − Age)* • `Id` *(random 100‑999)* |
| **`ProfData`** | Persists and manipulates profile data in a plaintext file. | `AddProfile()` • `ShowProfile()` • `SaveProfData()` • `LoadProfData()` • `ViewProfile()` • `UpdateProfile()` • `DeleteProfile()` |

---

## 🏗️ How It Works

1. **Launch** the app.
2. **Navigate** the `Menu` to select an action.
3. **Create** your first `Profile` — we’ll mint a random **ID** and calculate the **Year of Birth** for you.
4. **Store & Retrieve** data through the `ProfData` engine, which keeps everything in a handy `profiles.txt` file.

That’s it — simple, transparent, and totally offline‑friendly!

---

## ✨ Quick Start

```bash
# clone & run
$ git clone https://github.com/YOUR_USERNAME/ProfileHubApp.git
$ cd ProfileHubApp
$ dotnet run            # or use your favourite C# runner
```

You’ll be greeted by the **Menu**, ready to build your profile empire. 💪

---

## 📂 File Structure (mini)

```
ProfileHubApp/
├─ Menu.cs
├─ Profile.cs
├─ ProfData.cs
└─ README.md ← you are here
```

---

## 🤝 Contributing

Found a bug? Have a pun that could make the README even more radiant? PRs are welcome — just keep the good vibes rollin’.

---

## 📜 License

MIT, so feel free to fork, tweak, and share. Just don’t forget to give credit where it’s due.

---

**Happy profiling!** 🎈

