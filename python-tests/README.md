# JSONPlaceholder API Test Automation (Python + pytest)

This project is a small but production-style API automation suite targeting the
public [JSONPlaceholder](https://jsonplaceholder.typicode.com) REST API.

It demonstrates:

- API client abstraction (wrapper around `requests`)
- pytest fixtures and shared configuration
- Reusable assertion helpers
- Positive and negative testing for APIs
- Contract/schema checks on responses
- Basic pagination and query parameter validation
- Simple performance assertions

## Project Structure

```text
python-tests/
│
├── api_client.py          # HTTP client abstraction
├── conftest.py            # pytest fixtures (base URL, client, payloads)
├── helpers.py             # shared assertion helpers
├── requirements.txt       # dependencies
│
└── tests/
    ├── test_posts_happy_path.py        # main CRUD-style tests for /posts
    ├── test_posts_negative.py          # out-of-range and edge behavior
    ├── test_users_contracts.py         # response contract checks for /users
    ├── test_todos_filters.py           # query param / filtering behavior
    ├── test_pagination_and_limits.py   # _limit and _page usage
    └── test_performance.py             # basic response time checks
