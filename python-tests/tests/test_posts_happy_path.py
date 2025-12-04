# tests/test_posts_happy_path.py
import pytest
from helpers import assert_status_code, assert_has_keys


@pytest.mark.smoke
def test_get_posts_returns_list(api_client):
    response = api_client.get("/posts")
    assert_status_code(response, 200)

    data = response.json()
    assert isinstance(data, list)
    assert len(data) > 0

    first = data[0]
    assert_has_keys(first, ["userId", "id", "title", "body"])


@pytest.mark.smoke
def test_get_single_post_found(api_client):
    response = api_client.get("/posts/1")
    assert_status_code(response, 200)

    post = response.json()
    assert_has_keys(post, ["userId", "id", "title", "body"])
    assert post["id"] == 1


def test_create_post_echoes_payload(api_client, fresh_post_payload):
    response = api_client.post("/posts", json=fresh_post_payload)
    # JSONPlaceholder returns 201 for create
    assert_status_code(response, 201)

    created = response.json()
    # It will echo fields and add an id
    for key, value in fresh_post_payload.items():
        assert created.get(key) == value
    assert "id" in created


def test_update_post_put_replaces_fields(api_client, fresh_post_payload):
    update_payload = {
        "title": "updated test post",
        "body": "updated body content for this test.",
        "userId": 1
    }

    response = api_client.put("/posts/1", json=update_payload)
    assert_status_code(response, 200)

    updated = response.json()
    for key, value in update_payload.items():
        assert updated.get(key) == value
    assert updated["id"] == 1
