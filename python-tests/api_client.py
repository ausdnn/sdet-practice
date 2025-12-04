# api_client.py
import requests
from typing import Any, Dict, Optional


class ApiClient:
    def __init__(self, base_url: str, timeout: int = 10):
        self.base_url = base_url.rstrip("/")
        self.session = requests.Session()
        self.session.headers.update({
            "Accept": "application/json",
            "User-Agent": (
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) "
                "AppleWebKit/537.36 (KHTML, like Gecko) "
                "Chrome/120.0.0.0 Safari/537.36"
            )
        })
        self.timeout = timeout

    def _url(self, path: str) -> str:
        return f"{self.base_url}/{path.lstrip('/')}"

    def get(self, path: str, params: Optional[Dict[str, Any]] = None):
        return self.session.get(self._url(path), params=params, timeout=self.timeout)

    def post(self, path: str, json: Optional[Dict[str, Any]] = None):
        return self.session.post(self._url(path), json=json, timeout=self.timeout)

    def put(self, path: str, json: Optional[Dict[str, Any]] = None):
        return self.session.put(self._url(path), json=json, timeout=self.timeout)

    def delete(self, path: str):
        return self.session.delete(self._url(path), timeout=self.timeout)
