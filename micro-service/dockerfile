FROM node:18
WORKDIR /app
COPY package*.json .
# execute the following command - terminal , shell form
RUN npm install

COPY . .
EXPOSE 3000
#execute command directly and shell processing does not take place
CMD [ "node","server.js"]
#ENTRYPOINT [ "node" ]
#CMD ["server.js"]