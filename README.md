# 🧠 State Pattern — Document Workflow Example (C#)

This project demonstrates the **State Design Pattern** using a simple **document workflow**:

- A document starts as **Draft**
- It can be **Submitted** for review
- It can be **Published**, **Rejected**, **Sent back for revision**, or **Expired**
- Each state knows **what is allowed** and **what is forbidden**

Instead of a huge `if / else` or `switch` on a status enum, we model each state as a **separate class** that encapsulates its own behavior.

---

## 🎯 Problem (Before Using State Pattern)

In a real system, you usually start with something like this:

```csharp
// Pseudo bad version
if (status == Draft)
{
    // allow edit, submit
}
else if (status == UnderReview)
{
    // allow publish, reject, needs revision
}
else if (status == Published)
{
    // allow expire only
}
// ...
```

This becomes quickly:

- Hard to **read**
- Hard to **extend** (adding a new state breaks many places)
- Easy to **introduce bugs** (forgetting a condition in one of the `if`s)
- Full of **duplicated business rules**

The **State Pattern** fixes this by moving the logic from `if / else` into **state classes**.

---

## ✅ Solution — State Pattern

Each document state is represented by a class implementing a common interface:

```csharp
namespace StatePattern.State
{
    public interface IState
    {
        string Name { get; }

        void Edit(NewDocument doc);
        void Submit(NewDocument doc);
        void Publish(NewDocument doc);
        void Reject(NewDocument doc);
        void Expire(NewDocument doc);
    }
}
```

The `NewDocument` object holds the **current state** and delegates actions to it:

```csharp
namespace StatePattern.State
{
    public class NewDocument
    {
        private IState _state;

        public string StateName => _state.Name;

        public NewDocument()
        {
            _state = new DraftState();
        }

        public void ChangeState(IState newState)
        {
            _state = newState;
            Console.WriteLine($"[State] -> {_state.Name}");
        }

        public void ResetToDraft()
        {
            ChangeState(new DraftState());
            Console.WriteLine("Reset to Draft.");
        }

        public void Edit()    => _state.Edit(this);
        public void Submit()  => _state.Submit(this);
        public void Publish() => _state.Publish(this);
        public void Reject()  => _state.Reject(this);
        public void Expire()  => _state.Expire(this);
    }
}
```

Example of a concrete state – `DraftState`:

```csharp
namespace StatePattern.State
{
    public class DraftState : IState
    {
        public string Name => "Draft";

        public void Submit(NewDocument doc)
        {
            Console.WriteLine("📤 Submitted for review.");
            doc.ChangeState(new UnderReviewState());
        }

        public void Edit(NewDocument doc)
        {
            Console.WriteLine("✏️ Editing the document...");
        }

        public void Expire(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot expire from Draft.");
        }

        public void Publish(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot publish directly from Draft.");
        }

        public void Reject(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot reject in Draft.");
        }
    }
}
```

Example of another state – `ExpiredState`:

```csharp
namespace StatePattern.State
{
    public class ExpiredState: IState
    {
        public string Name => "Expired";

        public void Edit(NewDocument doc)
        {
            Console.WriteLine("❌ You cannot edit an expired document. Reset to Draft first.");
        }

        public void Submit(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot submit an expired document. Reset to Draft first.");
        }

        public void Publish(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot publish an expired document.");
        }

        public void Reject(NewDocument doc)
        {
            Console.WriteLine("❌ Cannot reject an expired document.");
        }

        public void Expire(NewDocument doc)
        {
            Console.WriteLine("ℹ️ Already expired.");
        }
    }
}
```
