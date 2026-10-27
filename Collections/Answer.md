Task 2.1 — Research: IReadOnlyDictionary & SortedDictionary

- IReadOnlyDictionary<TKey, TValue> is an interface  allows  to read key & value pairs and search for keys.
 can't add or remove items from it because it readonly 

 - Dictionary<TKey, TValue> is a class that allows  to add, remove, update, and retrieve items using their keys.

 - SortedDictionary<TKey, TValue> stores key & value using  keys.

 - Dictionary search by key is O (1) 
 - Sorted-Dictionary search by key is O(log n)
	

# Collection Scenarios

* **S1**: `Dictionary` — search by unique id is  O(1) .
* **S2**: `HashSet` — stores unique elements  .
* **S3**: `List` — when  insertion order values (like repeated grades).
* **S4**: `IReadOnlyDictionary` — Use when exposing key-value data publicly while enforcing strict encapsulation and preventing external modifications.
* **S5**: `SortedDictionary` — Use when key-value pairs (like sessions keyed by start time) must remain automatically ordered during frequent insertions.
* **S6**: `IEnumerable` — Use when returning a sequence intended only for iteration, allowing  stop early using yelid return keyword .

