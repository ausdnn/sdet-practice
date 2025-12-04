# tests/test_posts_negative.py
import pytest
from helpers import assert_status_code


@pytest.mark.regression
def test_get_nonexistent_post_returns_404(api_client):
    # JSONPlaceholder returns 404 for out-of-range IDs like 99999
    response = api_client.get("/posts/99999")
    assert_status_code(response, 404)
    # Body may be {}, empty, or non-JSON depending on implementation
    assert response.text == "" or response.text.strip() in ("{}", "[]", "")


@pytest.mark.regression
@pytest.mark.parametrize("post_id", [0, -1, "invalid"])
def test_get_post_with_invalid_id_formats_returns_404(api_client, post_id):
    response = api_client.get(f"/posts/{post_id}")
    # Again, real behavior: 404 for invalid IDs
    assert_status_code(response, 404)


@pytest.mark.regression
def test_delete_nonexistent_post_returns_200_or_404(api_client):
    # JSONPlaceholder fakes deletes; in practice you usually get 200,
    # but some proxies / updates may give 404. Accept both.
    response = api_client.delete("/posts/99999")
    assert response.status_code in (200, 404)
