import React from 'react';
import autobind from 'autobind-decorator';

require('./app.css');

@autobind
class ThemControl extends React.Component<{}, { value: string }> {
  constructor(props: {}) {
    super(props);
    this.state = { value: 'white' };
  }
  private handleChange(event: { target: { value: string }}) {
    this.setState({ value: event.target.value });
    document.documentElement.setAttribute('theme', event.target.value);
  }
  public render(): React.ReactNode {
    return (
      <label>Тема:
        <select id='themSelector' value={this.state.value} onChange={this.handleChange}>
          <option value='white'>белая</option>
          <option value='light-gray'>светло-серая</option>
          <option value='dark-gray'>темно-серая</option>
          <option value='design'>дизайнерская</option>
        </select>
      </label>
    );
  }
}

export default ThemControl;