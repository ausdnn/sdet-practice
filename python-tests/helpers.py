# helpers.py
from typing import Any, Dict


def assert_status_code(response, expected: int):
    assert response.status_code == expected, (
        f"Expected status {expected}, got {response.status_code}. "
        f"Body: {response.text}"
    )


def assert_has_keys(data: Dict[str, Any], keys):
    missing = [k for k in keys if k not in data]
    assert not missing, f"Missing expected keys: {missing}. Data: {data}"


def assert_response_time_under(elapsed: float, threshold_seconds: float):
    assert elapsed < threshold_seconds, (
        f"Response too slow: {elapsed:.3f}s (threshold {threshold_seconds:.3f}s)"
    )
