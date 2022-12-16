import Ajax from './ajax.js'

const companyList = document.getElementById('company'),
    countryList = document.getElementById('country'),
    departmentList = document.getElementById('department'),
    locationList = document.getElementById('location'),
    createButton = document.getElementById('createBtn'),
    loadDropdown = (select, items) => {
        while (select.firstChild) {
            select.removeChild(select.firstChild);
        }
        items.forEach(item => select.add(new Option(item.name, item.name)))
    },
    getData = () => {
        let formData = new FormData(document.getElementById('form'))
        var data = {};
        formData.forEach((value, key) => data[key] = value);
        return data;
    };

createButton.addEventListener('click', () => {
    let formData = getData();
    console.log(formData);
})