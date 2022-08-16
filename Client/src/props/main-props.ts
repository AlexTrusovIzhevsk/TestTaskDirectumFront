import IHeaderProps from './header-props';

interface IAppProps extends IHeaderProps{
  category: string | null;
}

export default IAppProps;