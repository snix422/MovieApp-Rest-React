FROM node:20 AS build

WORKDIR /app

# Kopiujemy pliki package.json i package-lock.json
COPY ./package*.json ./

# Instalujemy zależności
RUN npm install

# Kopiujemy cały kod źródłowy
COPY . .

# Budujemy aplikację (Vite, CRA itd.)
RUN npm run build

# --- Etap produkcyjny ---
FROM nginx:alpine

# Kopiujemy pliki zbudowane z poprzedniego etapu
COPY --from=build /app/dist /usr/share/nginx/html

# Kopiujemy własną konfigurację nginx (jeśli ją masz)
COPY ./nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
