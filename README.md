# Todo App
This is a simple Todo application built with Blazor and .NET as part of a technical assignment.

The purpose of the application is to demonstrate understanding of component-based UI development, state management, and basic CRUD operations.

---

## Current Functionality

The application currently supports:

- Creating new todos
- Displaying a list of active todos
- Marking a todo as completed
- Automatically moving completed todos to a history list
- Deleting todos from both active and completed lists

When a todo is marked as completed, it is immediately removed from the active list and added to the history section.

---


## Technical Details

- Built with **Blazor**
- Uses **.NET**
- In-memory state management via singleton service
- Component-based architecture
- Event-driven UI updates

---

## Possible Next Steps

The next improvements would include:

- Persisting data (e.g., database or local storage)
- Adding edit functionality for todos
- Implementing filtering (All / Active / Completed)
- Adding unit tests
- Improving UI styling and responsiveness
- Introducing user authentication and per-user todo lists

---