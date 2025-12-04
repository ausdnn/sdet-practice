# tests/test_users_contracts.py
import pytest
from helpers import assert_status_code, assert_has_keys


@pytest.mark.regression
def test_users_list_contract(api_client):
    response = api_client.get("/users")
    assert_status_code(response, 200)

    users = response.json()
    assert isinstance(users, list)
    assert len(users) > 0

    user = users[0]
    # High-level contract
    assert_has_keys(user, ["id", "name", "username", "email", "address", "phone", "website", "company"])

    # Address nested contract
    address = user["address"]
    assert_has_keys(address, ["street", "suite", "city", "zipcode", "geo"])
    assert_has_keys(address["geo"], ["lat", "lng"])

    # Company nested contract
    company = user["company"]
    assert_has_keys(company, ["name", "catchPhrase", "bs"])


@pytest.mark.regression
def test_user_emails_have_at_symbol(api_client):
    response = api_client.get("/users")
    assert_status_code(response, 200)

    users = response.json()
    for user in users:
        email = user.get("email", "")
        assert "@" in email
