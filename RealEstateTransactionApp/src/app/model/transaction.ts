export interface Transaction {
  id: number;
  street: string;
  city: string;
  zip: string;
  state: string;
  beds: number;
  baths: number;
  sq__ft: string;
  type: string;
  sale_date: string;
  price: number;
  latitude: number;
  longitude: number;
  isEdit: boolean;
}

export const TransactionColumns = [
  {
    key: 'street',
    type: 'text',
    label: 'Street',
    required: true,
  },
  {
    key: 'city',
    type: 'text',
    label: 'City',
  },
  {
    key: 'zip',
    type: 'text',
    label: 'Zip',
    required: true,
  },
  {
    key: 'state',
    type: 'text',
    label: 'State',
  },
  {
    key: 'beds',
    type: 'number',
    label: 'Beds',
  },
  {
    key: 'baths',
    type: 'number',
    label: 'Baths',
  },
  {
    key: 'sq__ft',
    type: 'text',
    label: 'SQ_FT',
  },
  {
    key: 'type',
    type: 'text',
    label: 'Type',
  },
  {
    key: 'sale_date',
    type: 'date',
    label: 'Sale Date',
  },
  {
    key: 'price',
    type: 'number',
    label: 'Price',
  },
  {
    key: 'latitude',
    type: 'number',
    label: 'Latitude',
  },
  {
    key: 'longitude',
    type: 'number',
    label: 'Longitude',
  },
  {
    key: 'isEdit',
    type: 'isEdit',
    label: '',
  },
];
