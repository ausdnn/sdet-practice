# SDET Practice Portfolio

This repository showcases my end-to-end SDET skill set through two focused domains:

1. **UI Test Automation (C# + Selenium + Page Object Model)**
2. **API Automation (Python + Pytest + JSONPlaceholder)**

The goal of this project is to demonstrate real-world automation structure, test design, reusable utilities, and professional workflow patterns commonly expected in modern QA engineering.


---

## Technologies Used

### **UI Automation (C# / Selenium)**
- Selenium WebDriver  
- NUnit  
- Page Object Model (POM)  
- WebDriverWait / ExpectedConditions  
- ChromeDriver  

### **API Automation (Python / Pytest)**
- Python 3.11+  
- Pytest  
- Requests  
- JSONPlaceholder API  
- Custom assertion helpers  
- Pytest markers (smoke, regression, negative)  

---

## UI Automation Overview (C# + Selenium)

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

## How to Run the Tests

### **Running UI Tests (C# / Selenium)**
```sh
cd csharp-ui-tests

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
