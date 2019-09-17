# BurgerShack 

We need an api for the following items


```csharp
interface IItem
{
  string Name {get; set;}
  string Description {get; set;}
  decimal Price {get; set;}
}
```



- Burgers
  - GET: /api/[resource]
  - POST: /api/[resource]
    - creates a new [item]
  - PUT: /api/[resource]/[id]
  - DELETE: NO
- Drinks
  - GET: /api/[resource]
  - POST: /api/[resource]
    - creates a new [item]
  - PUT: /api/[resource]/[id]
  - DELETE: NO
- Sides
  - GET: /api/[resource]
  - POST: /api/[resource]
    - creates a new [item]
  - PUT: /api/[resource]/[id]
  - DELETE: NO
- Menu
  - GET: Return a menu of all IItems categorized by their type