.PHONY: api

api:
	@docker compose up -d sqlserver
	@docker compose up --abort-on-container-exit --exit-code-from migrations