api:
	docker compose up -d --build

test:
	docker build --target testApplication -t applicationtests:latest .
	docker run applicationtests:latest

	docker build --target testDomain -t domaintests:latest .
	docker run domaintests:latest