class Ajax {
  static ajax(url, method, headers = null, requestBody = null) {
    if (method == 'GET') {
      requestBody = null;
    }
    if (headers == null) {
      headers = {}
    }
    headers['method'] = method;

    if (requestBody != null) {
      requestBody = JSON.stringify(requestBody);
    }
    return fetch(url, {
      method: method, // *GET, POST, PUT, DELETE, etc.
      mode: 'same-origin', // no-cors, *cors, same-origin
      cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
      credentials: 'same-origin', // include, *same-origin, omit
      headers: {
        'content-type': 'application/json'
      },
      redirect: 'follow', // manual, *follow, error
      referrerPolicy: 'same-origin', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
      body: requestBody // body data type must match "Content-Type" header
    });
  }

  static get(url, headers = null) {
    return this.ajax(url, 'GET', headers);
  }

  static post(url, body, headers = null) {    
    return this.ajax(url, 'POST', headers, body);
  }

  static put(url, body, headers = null) {
    return this.ajax(url, 'PUT', headers, body);
  }

  static delete(url, body, headers = null) {
    return this.ajax(url, 'DELETE', headers, body);
  }
}

const checkboxes = ['vpn', 'outlookMailbox', 'confidential'],
    companyList = document.getElementById('company'),
    countryList = document.getElementById('country'),
    departmentList = document.getElementById('department'),
    locationList = document.getElementById('location'),
    createButton = document.getElementById('createBtn'),
    loadDropdown = (dropdownList, items) => {
        while (dropdownList.firstChild) {
            dropdownList.removeChild(dropdownList.firstChild);
        }
        items.forEach(item => dropdownList.add(new Option(item.name, item.name)))
    },
    getData = () => {
        let formData = new FormData(document.getElementById('form')),
          data = {
            firstName: null,
            lastName: null,
            shortName: null,
            description: null,
            displayName: null,
            jobTitle: null,
            country: null,
            location: null,
            company: null,
            manager: null,
            costCenter: null,
            department: null,
            vpn: false,
            outlookMailbox: false,
            confidential: false
          };
      formData.forEach((value, key) => {
        if (checkboxes.includes(key)) {
          data[key] = value == 'on';
        } else {
          data[key] = value
        }        
      });
        return data;
    };

createButton.addEventListener('click', () => {
  let formData = getData();
  console.log(formData);
  Ajax.post('/api/User', formData).then(r => {
    console.log(r);
  })
})