var express = require('express');
const axios = require('axios');
var router = express.Router();

router.get('/', async (req, res, next) => {
    try {
        const response = await axios.get(`${process.env.API_URL}/api/pings`);

        res.json(response.data);
    } catch (e) {
        next(e);
    }
});

module.exports = router;
