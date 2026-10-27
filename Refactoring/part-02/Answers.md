# Part 02 — answers

---

## Reports

- What was the problem?
	 Code was duplicated across all report classes, repeating the exact same loading, validation, and saving logic.

- What did you change?
	Created an abstract base class (ReportExporter) for the shared steps.
	leaving only the unique formatting to each report subclass.
- Why did you choose that approach?
Abstract classes allow sharing implementation logic and state, 
whereas interfaces cannot store fields or share code as cleanly
---

## Enrollment

- What was the problem?
 The caller (`Program.cs`) previously had to manually instantiate and coordinate four separate subsystems (`PaymentGateway`, `SeatInventory`, `InvoiceGenerator`, and `EmailService`) in the correct order, leading to tightly coupled and cluttered client code.
 The Facade centralizes this workflow into a single unified method (`Enroll`).

- What did you change?
Created the EnrollmentFacade class to encapsulate all four subsystems (PaymentGateway, SeatInventory, InvoiceGenerator, and EmailService) behind a single Enroll method, and updated Program.cs to use the facade instead of instantiating and calling the services individually.

- Why did you choose that approach?
	To hide complex subsystem interactions and remove tight coupling, ensuring the caller only needs to interact with one unified interface rather than managing multiple dependent services directly.
