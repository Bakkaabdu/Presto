# 🥙 Presto Shawarma Ordering System (Console App)

Welcome to **Presto**, a console-based ordering system designed to simulate a shawarma restaurant experience. This app allows users to build customized shawarma orders, manage selections, edit choices, and calculate totals in an intuitive CLI-based workflow.

---

## 🚀 Features

- Choose between shawarma wrap or plate
- Customize your order with bread, protein, rice, sides, and add-ons
- Calculate running subtotal with extras (e.g., extra meat, fries, sauces)
- Modify specific parts of your order (edit entree, bread, protein, etc.)
- Simple and clean user prompts
- Easily extendable and testable architecture

---

## 🛠️ Project Structure

---

## 🧩 Core Classes

### `Menu`
Represents an individual item on the menu with a name and price.

### `OrderInputAndOptions`
Handles:
- Storing current and finalized shawarma builds
- Displaying menus
- Getting and validating user input
- Calculating and updating totals

### `EditOrderItem`
Allows the user to:
- Revisit and change selected options
- Clear and reselect parts of the current shawarma build

### `CustomerReceipt`
Calculates running subtotal of the current order.

---

## 💡 How It Works

1. The user starts by selecting an entree type (wrap or plate).
2. The app then guides the user through selecting bread, protein, rice, sides, and extras.
3. Subtotals are calculated in real-time after key selections (e.g., meat, extras).
4. The user can finalize their shawarma or choose to edit any part before confirming the order.
5. All finalized shawarmas are stored in a list for receipt generation.

---

## 📦 Requirements

- .NET SDK
- A C# IDE (e.g., Visual Studio, Rider, or VS Code with C# extension)

- ## 🛠️ How to Run

```bash
git clone https://github.com/your-username/presto-shawarma.git](https://github.com/Bakkaabdu/Presto
dotnet build

dotnet run



