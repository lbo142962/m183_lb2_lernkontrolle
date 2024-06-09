export interface INavbarProps {
    searchInput: string
    filterSelection: string
    setSearchInput: React.Dispatch<React.SetStateAction<string>>,
    setFilterSelection: React.Dispatch<React.SetStateAction<string>>,
}