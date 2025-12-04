# tests/test_todos_filters.py
import pytest
from helpers import assert_status_code


@pytest.mark.regression
def test_todos_filtered_by_user(api_client):
    response = api_client.get("/todos", params={"userId": 1})
    assert_status_code(response, 200)

    todos = response.json()
    assert len(todos) > 0

    for todo in todos:
        assert todo["userId"] == 1


@pytest.mark.regression
def test_todos_filtered_by_completion_status(api_client):
    # JSONPlaceholder accepts query params like ?completed=true
    response = api_client.get("/todos", params={"completed": "true"})
    assert_status_code(response, 200)

    todos = response.json()
    assert len(todos) > 0

    for todo in todos:
        assert todo["completed"] is True
