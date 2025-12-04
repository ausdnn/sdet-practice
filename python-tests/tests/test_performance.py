# tests/test_performance.py
import time
import pytest
from helpers import assert_status_code, assert_response_time_under


@pytest.mark.performance
def test_get_posts_under_1_second(api_client):
    start = time.time()
    response = api_client.get("/posts")
    elapsed = time.time() - start

    assert_status_code(response, 200)
    assert_response_time_under(elapsed, 1.0)


@pytest.mark.performance
def test_get_users_under_1_second(api_client):
    start = time.time()
    response = api_client.get("/users")
    elapsed = time.time() - start

    assert_status_code(response, 200)
    assert_response_time_under(elapsed, 1.0)
