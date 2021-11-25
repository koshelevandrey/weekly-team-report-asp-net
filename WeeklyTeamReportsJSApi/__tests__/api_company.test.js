const frisby = require('frisby');
const {API_URL_START} = require("../utils/config");
const Joi = frisby.Joi;

it('should return a status of 200 after get', function () {
    return frisby
        .get(API_URL_START + '/companies')
        .expect('status', 200);
});

it('should return list of companies', function () {
    return frisby
        .get(API_URL_START + '/companies')
        .expect('status', 200)
        .expect('jsonTypes', '*', {
            'companyId': Joi.number().required(),
            'name': Joi.string().required(),
            'joinedDate': Joi.date().required(),
        });
});

it('should return a status of 404 after get', function () {
    return frisby
        .get(API_URL_START + '/companies/0')
        .expect('status', 404);
});

it('should return a company', function () {
    return frisby
        .get(API_URL_START + '/companies/3')
        .expect('status', 200)
        .expect('jsonTypes', {
            'companyId': Joi.number().required(),
            'name': Joi.string().required(),
            'joinedDate': Joi.date().required(),
        });
});

//Example post URL: http://localhost:5001/api/companies?Name=1234&JoinedDate=2005-05-05
it('should post a company', function () {
    let name = "JsTestApiCompany";
    let joinedDate = new Date(Date.now()).toISOString().substring(0, 10);
    return frisby
        .post(API_URL_START + '/companies?' + "Name=" + name + "&JoinedDate=" + joinedDate)
        .expect('status', 200)
        .expect('jsonTypes', {
            'companyId': Joi.number().required(),
            'name': Joi.string().required(),
            'joinedDate': Joi.date().required(),
        });
});

// Example put URL: http://localhost:5001/api/companies?CompanyId=64&Name=12&JoinedDate=2002-01-01
it('should post and then update a company', function () {
    let name = "NotYetUpdatedJsTestApiCompany";
    let joinedDate = new Date(Date.now()).toISOString().substring(0, 10);
    return frisby
        .post(API_URL_START + '/companies?' + "Name=" + name + "&JoinedDate=" + joinedDate)
        .expect('status', 200)
        .expect('jsonTypes', {
            'companyId': Joi.number().required(),
            'name': Joi.string().required(),
            'joinedDate': Joi.date().required(),
        })
        .then(function (res) {
            let companyId = res.json.companyId;
            let newName = "UpdatedJsTestApiCompany";
            let newJoinedDate = "2005-05-05";

            return frisby
                .put(API_URL_START + '/companies?' + "CompanyId=" + companyId + "&Name=" + newName +
                    "&JoinedDate=" + newJoinedDate)
                .expect('status', 200);
        })
});

it('should return a status of 404 after trying to update a non existing company', function () {
    let companyId = 0;
    let name = "404UpdatedJsTestApiCompany";
    let joinedDate = '2001-01-01';
    return frisby
        .put(API_URL_START + '/companies?' + "CompanyId=" + companyId + "&Name=" + name +
            "&JoinedDate=" + joinedDate)
        .expect('status', 404);
});

// Example delete URL: http://localhost:5001/api/companies/1
it('should post and then delete a company', function () {
    let name = "ToBeDeletedCompany";
    let joinedDate = new Date(Date.now()).toISOString().substring(0, 10);
    return frisby
        .post(API_URL_START + '/companies?' + "Name=" + name + "&JoinedDate=" + joinedDate)
        .expect('status', 200)
        .expect('jsonTypes', {
            'companyId': Joi.number().required(),
            'name': Joi.string().required(),
            'joinedDate': Joi.date().required(),
        })
        .then(function (res) {
            let companyId = res.json.companyId;

            return frisby
                .del(API_URL_START + '/companies/' + companyId)
                .expect('status', 200);
        })
});

it('should return a status of 404 after trying to delete a non existing company', function () {
    let companyId = 0;
    return frisby
        .del(API_URL_START + '/companies/' + companyId)
        .expect('status', 404);
});