# Generics Tasks: Answers & Commits

## Step 2: StudentStore vs itemStore
* **What is the same:** Both stores share the exact same structural logic, internal collection type (`List<T>`), and method signatures (`Add`, `GetById`, `GetAll`, `Remove`).
* **What is different:** The underlying data type being managed (`Student` vs `item`) and their unique domain properties (`Name` vs `Price`).
* **Step Commit Message:** `git commit -m "Step 2 - Add item and itemStore"`

---

## Step 3: One class for both & Compiler Error

### Compiler Error:

CS1061: 'T' does not contain a definition for 'Id' and no accessible extension method 'Id' accepting a first argument of type 'T' could be found (are you missing a using directive or an assembly reference?)



## Step 2
`StudentStore` and `CourseStore` have similar methods: `Add`, `GetById`, `GetAll`, and `Remove`. The main difference is the type of objects they manage. This duplication can be reduced by creating a generic `Store<T>`.

## Step 3
The compiler cannot access `item.Id` when `T` is unrestricted, because not every type has an `Id` property. Adding the constraint `where T : IHasId` guarantees that `T` implements `IHasId` and provides an `Id`.

## Step 7
I tested the generic stores with five students and three courses. I retrieved objects by ID, handled the exception for a duplicate student ID, printed page 2 with a page size of 2, and called `FindById` on a regular `List<Course>`.

`Store<string>` must not compile because `string` does not implement `IHasId`, which is required by the generic constraint.

## Search
**Question:** What is the common name for the kind of class built in Steps 4 and 5?

**Answer:** A Repository is a common name for a class that manages access to objects, such as adding, finding, retrieving, and removing them. The exact intended answer depends on what Steps 4 and 5 asked you to build.