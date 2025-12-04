# conftest.py
import os
import pytest
from dotenv import load_dotenv
from api_client import ApiClient

load_dotenv()


@pytest.fixture(scope="session")
def base_url():    
    return os.getenv("API_BASE_URL", "https://jsonplaceholder.typicode.com")


@pytest.fixture(scope="session")
def api_client(base_url):
    return ApiClient(base_url=base_url)


@pytest.fixture
def fresh_post_payload():
    return {
        "title": "test post from api suite",
        "body": "this is a test payload used for API automation practice.",
        "userId": 1
    }
