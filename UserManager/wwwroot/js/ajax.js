export default class Ajax {
    static ajax(url, method, headers = null, requestBody = null) {
        if (method == 'GET') {
            requestBody = null;
        }
        if (headers == null) {
            headers = {}
        }
        headers['Content-Type'] = 'application/json';
        if (requestBody != null) {
            requestBody = JSON.stringify(requestBody);
        }
        return fetch(url, {
            body: requestBody,
            headers: headers,
            method: method,
            mode: 'same-origin'
        });
    }

    static get(url, headers = null) {                
        return this.ajax(url, 'GET', headers);
    }

    static post(url, body, headers = null) {``
        return this.ajax(url, 'POST', headers, body); 
    }

    static put(url, body, headers = null) {
        return this.ajax(url, 'PUT', headers, body); 
    }

    static delete(url, body, headers = null) {
        return this.ajax(url, 'DELETE', headers, body); 
    }
}