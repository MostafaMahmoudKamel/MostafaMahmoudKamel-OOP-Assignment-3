# Part 03 — answers

---

## BlockedUsers

- Time complexity before: O(n)
- Time (ms) before: 1 ms
- What did you change? change from list to hashSet because it making search in O(1) 
- Time complexity after:O(1)
- Time (ms) after: 1 ms

---

## Students

- What was the problem?
The method eagerly created and loaded 1,000,000 Student objects into memory all at once, even though the consumer only needed the first 3.
- What did you change?
 Changed the return type to IEnumerable<Student> and used yield return to enable lazy evaluation,
- so students are created and execution stops after the first 3.
