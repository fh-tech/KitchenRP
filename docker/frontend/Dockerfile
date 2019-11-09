
### STAGE 1: setup ###

# We label our stage as ‘setup’
FROM node:10-alpine as setup

COPY ./kitchenRP-frontend/kitchenRP/package.json ./kitchenRP-frontend/kitchenRP/package-lock.json ./

## Storing node modules on a separate layer will prevent unnecessary npm installs at each build
RUN npm ci && mkdir /ng-app && mv ./node_modules ./ng-app

WORKDIR /ng-app

COPY ./kitchenRP-frontend/kitchenRP .

FROM setup as builder
## Build the angular app in production mode and store the artifacts in dist folder
RUN npm run ng build -- --prod --output-path=dist

### Stage 2 Runtime
FROM nginx:stable-alpine

COPY ./docker/frontend/nginx.conf /etc/nginx/conf.d/

## Remove default nginx website
RUN rm -rf /usr/share/nginx/html/*

## From ‘builder’ stage copy over the artifacts in dist folder to default nginx public folder
COPY --from=builder /ng-app/dist /usr/share/nginx/html

CMD ["nginx", "-g", "daemon off;"]
