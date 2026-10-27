# Part 01 — Answers

---

## ShippingCostCalculator
	
- **What was the problem?**
  The original code violated the Open/Closed Principle (OCP) because adding a new shipping carrier required modifying existing core logic and switch statements.

- **What did you change?**
  Introduced the `ICostCalculator` interface to decouple the calculation logic, allowing new carriers (like `Fast`) to be seamlessly integrated via polymorphism without touching any existing code.

---

## OrderProcessor

- **What was the problem?**
  The code suffered from tight coupling where the high-level `OrderProcessor` depended directly on concrete low-level components (`SqlOrderRepository` and `SmtpEmailSender`), violating the Dependency Inversion Principle (DIP).

- **What did you change?**
  Applied Dependency Injection by introducing `ISqlOrder` and `IsmtpEmailSender` abstractions, ensuring that both high-level and low-level modules depend on abstractions rather than concrete implementations.

---

## Notifications

- **What was the problem?**
  The notification classes suffered from class explosion and tight coupling due to rigid inheritance (creating separate classes for every possible combination like `UrgentScheduledEmailNotification`), which violated the OCP and DRY principles.

- **What did you change?**
  Refactored the notification system using **Composition over Inheritance** and the **Decorator Pattern**. Introduced the `INotification` contract for core channels (`EmailNotification`, `SmsNotification`) and created reusable wrappers (`UrgentNotification` and `ScheduledNotification`), allowing behaviors to be dynamically combined on any channel without redundant classes.

---

## Proof

- **New carrier file(s):**  
  `Fast.cs` (Implementing `ICostCalculator`)

- **New notification channel file(s):**  
  `TelgramNotification.cs` (Implementing `INotification`)

- **Existing classes left unchanged? (yes/no):**  
  `yes`