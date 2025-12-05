# SDET Practice Portfolio

This repository showcases my end-to-end SDET skill set through two focused domains:

1. **UI Test Automation (C# + Playwright + Page Object Model)**
2. **API Automation (Python + Pytest + JSONPlaceholder)**
3. **.NET Test Automation (C# + NUnit for API & Unit Tests)**
The goal of this project is to demonstrate real-world automation structure, test design, reusable utilities, and professional workflow patterns commonly expected in modern QA engineering.


---

## Technologies Used

### **UI Automation (C# / Playwright)**
- Microsoft Playwright for .NET
- NUnit  
- Page Object Model (POM)  
- Cross-browser support (Chromium, Firefox, WebKit)
- Playwright Test Fixtures  

### **API Automation (Python / Pytest)**
- Python 3.11+  
- Pytest  
- Requests  
- JSONPlaceholder API  
- Custom assertion helpers  
- Pytest markers (smoke, regression, negative)  

---

## UI Automation Overview (C# + Playwright)

The UI portion uses **Page Object Model** to keep tests clean, readable, and maintainable.

### Highlights
- Reusable element locators and UI actions  
- Composable page workflows  
- Structured NUnit tests  
- Centralized driver setup  
- Expandable to support multiple browsers  

---

## API Automation Overview (Python + Pytest)

The API test suite validates CRUD behavior using the JSONPlaceholder service.

### Key Capabilities
- Full **happy path** and **negative** test coverage  
- Reusable **api_client** for HTTP operations  
- Shared pytest fixtures for session, base URL, and payloads  
- Validation helpers to avoid repetitive assertions  
- Tests grouped by functionality (auth, posts, negative, regression, etc.)

Example tests include:
- GET → Validate response shape & status  
- POST → Echo payload and validate  
- PUT/PATCH → Update fields with full/partial payload  
- DELETE → Validate expected behavior  
- Negative path coverage for invalid IDs and formats  

---

## .NET Test Automation Overview (C# / NUnit)
### *(dotnet-tests)*

The `dotnet-tests` directory contains standalone test projects demonstrating backend API testing, unit testing, and utility-driven test design using modern C#.

### Includes:
- **API Tests** using `HttpClient` or `RestSharp`
- **Unit Tests** using NUnit
- Reusable helpers for:
  - JSON serialization
  - Status code validation
  - Response schema checks
  - Test data objects

### Example Capabilities
- Send **GET / POST / PUT / PATCH / DELETE** requests
- Validate API responses (status codes, schema, timing, values)
- Mock or stub logic for isolated unit tests
- Verify business logic through small focused test cases

---

## How to Run the Tests

### **Running UI Tests (C# / Playwright)**
```sh
cd playwright-tests/UiTests

dotnet restore

dotnet test
```

### **Running API Tests (Python/Pytest)**
```sh
cd python-tests

python -m venv venv

.\venv\Scripts\activate

pip install -r requirements.txt

pytest
```

#### Run by specific marker designated with pytest.ini
```sh
pytest -m regression
```

### **Running .NET API/Unit Tests (C# / NUnit)**
```sh
cd dotnet-tests/ApiTests

dotnet restore
dotnet test
```

```sh
cd dotnet-tests/UnitTests

dotnet test
```

