var express = require('express');
const axios = require('axios');
const FormData = require('form-data');
var multer  = require('multer');
var storage = multer.memoryStorage()
var upload = multer({ storage: storage })
var router = express.Router();

router.get('/', async (req, res, next) => {
    try {
        const response = await axios.get(`${process.env.API_URL}/api/images`, { responseType: 'arraybuffer'});

        res.type('png').status(200).end(response.data);
    } catch (e) {
        next(e);
    }
});

router.post('/', upload.single('file'), async (req, res, next) => {
    const file = req.file
    try {
        let formData = new FormData();
        formData.append('file', file.buffer, file.originalname);

        const response = await axios.post(`${process.env.API_URL}/api/images`, formData, {
            responseType: 'arraybuffer',
            headers: {
              'Content-Type': `multipart/form-data; boundary=${formData._boundary}`
            }
        });

        res.type('png').status(200).end(response.data);
    } catch (e) {
        next(e);
    }
});

module.exports = router;
