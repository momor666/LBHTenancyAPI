#!/bin/bash

curl https://cli-assets.heroku.com/install.sh | sh

cat > ~/.netrc << EOF
machine api.heroku.com
  login $HEROKU_LOGIN
  password $HEROKU_API_KEY
EOF
