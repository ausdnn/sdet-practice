# tests/test_pagination_and_limits.py
import pytest
from helpers import assert_status_code


@pytest.mark.regression
def test_posts_limit_parameter_reduces_result_count(api_client):
    response = api_client.get("/posts", params={"_limit": 10})
    assert_status_code(response, 200)

    posts = response.json()
    assert isinstance(posts, list)
    assert len(posts) <= 10


@pytest.mark.regression
def test_posts_pagination_like_behavior(api_client):
    resp_page1 = api_client.get("/posts", params={"_page": 1, "_limit": 5})
    resp_page2 = api_client.get("/posts", params={"_page": 2, "_limit": 5})

    assert_status_code(resp_page1, 200)
    assert_status_code(resp_page2, 200)

    page1_posts = resp_page1.json()
    page2_posts = resp_page2.json()

    assert len(page1_posts) > 0
    assert len(page2_posts) > 0

    ids_page1 = {p["id"] for p in page1_posts}
    ids_page2 = {p["id"] for p in page2_posts}

    # We expect different sets for different pages
    assert ids_page1 != ids_page2
