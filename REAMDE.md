### Different scenarios
1. `Remove-Item alias:curl`
2. `curl -v http://localhost:5000/api/pings`
3. `curl -v -o tux.png http://localhost:5000/api/images`
4. `curl -v -o push.png -F "file=@./pusheen.png" http://localhost:5000/api/images`

### Dockerization Backend
1. `dotnet publish --framework net472  --self-contained false -o ./publish`
2. `docker build -f .\Dockerfile -t terravenil/imageyrotator:v1.0 .`
3. `docker run -p 5000:5000 imageyrotator:v1.0`

### Dockerization Frontend
1. `docker build -f .\Dockerfile -t terravenil/imageyrotator-fronend:v1.0 .`
2. `docker run -p 3000:3000 terravenil/imageyrotator-fronend:v1.0`

### Wine specific
1. `docker images terravenil/imageyrotator:v1.0`
2. `docker run --rm --entrypoint /bin/bash -e DISPLAY=host.docker.internal:0 -p 5000:5000 -it terravenil/imageyrotator:v1.0`

### K8s deployment
1. `kubectl create namespace imageyrotator-app`
2. `kubectl apply -f .\kubernetes`
3. `kubectl get cm,pods,deploy,sa,svc -n imageyrotator-app`
4. `kubectl port-forward -n imageyrotator-app pod/frontend-66df7c957b-5wrzb 3000:3000`
5. `kubectl delete all --all -n imageyrotator-app`
6. `kubectl delete namespace imageyrotator-app`

### OSM onboard services
1. `kubectl create namespace imageyrotator-app`
2. `osm namespace add imageyrotator-app`
3. `kubectl apply -f .\osm\`

### OSM features
1. Grafana - `osm dashboard`